using MemoQ.PreviewInterfaces.Interfaces;
using MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication;
using MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model;
using MemoQ.PreviewInterfaces.ProtcolWrappers.REST.MessageHandlers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Timers;
using System.Web.Http;
using System.Web.Http.Routing;
using System.Web.Http.SelfHost;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Callback
{
    internal class CallbackService : ICallbackHandler
    {
        private readonly string baseAddress;
        private readonly CallbackHandler callbackHandler;
        private readonly int pingIntervalInSecs;
        private readonly Action onConnectionClosed;
        private readonly HttpSelfHostServer serviceHost;
        private Timer timeoutTimer;

        private MessagePartInfo contentUpdateMessagePartInfo;
        private MessagePartInfo changeHighlightMessagePartInfo;
        private MessagePartInfo previewPartIdUpdateMessagePartInfo;
        private List<ContentUpdateRequestFromMQ> contentUpdateMessageParts;
        private List<ChangeHighlightRequestFromMQ> changeHighlightMessageParts;
        private List<PreviewPartIdUpdateRequestFromMQ> previewPartIdUpdateMessageParts;

        public CallbackService(string baseAddress, CallbackHandler callbackHandler, int pingIntervalInSecs, Action onConnectionClosed)
        {
            this.baseAddress = baseAddress;
            this.callbackHandler = callbackHandler;
            this.pingIntervalInSecs = pingIntervalInSecs;
            this.onConnectionClosed = onConnectionClosed;

            contentUpdateMessageParts = new List<ContentUpdateRequestFromMQ>();
            changeHighlightMessageParts = new List<ChangeHighlightRequestFromMQ>();
            previewPartIdUpdateMessageParts = new List<PreviewPartIdUpdateRequestFromMQ>();

            var config = getWebApiConfiguration();
            serviceHost = new HttpSelfHostServer(config);
        }

        public void Start()
        {
            serviceHost.OpenAsync().Wait();
        }

        public void Stop()
        {
            timeoutTimer?.Stop();
            if (serviceHost != null)
            {
                serviceHost.CloseAsync().Wait();
                serviceHost.Dispose();
            }
        }

        void ICallbackHandler.HandlePingRequest()
        {
            Console.WriteLine("Ping");
            onRequestReceived();
        }

        void ICallbackHandler.HandleContentUpdateRequest(ContentUpdateRequestFromMQ contentUpdateRequest, MessagePartInfo messagePartInfo)
        {
            onRequestReceived();

            assembleMessageParts(
                ref contentUpdateMessagePartInfo,
                ref contentUpdateMessageParts,
                messagePartInfo,
                contentUpdateRequest,
                () =>
                {
                    List<PreviewPart> previewParts = new List<PreviewPart>();
                    foreach (var messagePart in contentUpdateMessageParts)
                        previewParts.AddRange(messagePart.PreviewParts);

                    var request = new ContentUpdateRequestFromMQ()
                    {
                        PreviewParts = previewParts.ToArray()
                    };

                    callbackHandler.QueueContentUpdateRequest(request.Convert());
                });
        }

        void ICallbackHandler.HandleChangeHighlightRequest(ChangeHighlightRequestFromMQ changeHighlighRequest, MessagePartInfo messagePartInfo)
        {
            onRequestReceived();

            assembleMessageParts(
                ref changeHighlightMessagePartInfo,
                ref changeHighlightMessageParts,
                messagePartInfo,
                changeHighlighRequest,
                () =>
                {
                    List<PreviewPartWithFocusedRange> previewParts = new List<PreviewPartWithFocusedRange>();
                    foreach (var messagePart in changeHighlightMessageParts)
                        previewParts.AddRange(messagePart.ActivePreviewParts);

                    var request = new ChangeHighlightRequestFromMQ()
                    {
                        ActivePreviewParts = previewParts.ToArray()
                    };

                    callbackHandler.QueueChangeHighlightRequest(request.Convert());
                });
        }

        void ICallbackHandler.HandlePreviewPartIdUpdateRequest(PreviewPartIdUpdateRequestFromMQ previewPartIdUpdateRequest, MessagePartInfo messagePartInfo)
        {
            onRequestReceived();

            assembleMessageParts(
                ref previewPartIdUpdateMessagePartInfo,
                ref previewPartIdUpdateMessageParts,
                messagePartInfo,
                previewPartIdUpdateRequest,
                () =>
                {
                    List<string> previewPartIds = new List<string>();
                    foreach (var messagePart in previewPartIdUpdateMessageParts)
                        previewPartIds.AddRange(messagePart.PreviewPartIds);

                    var request = new PreviewPartIdUpdateRequestFromMQ()
                    {
                        PreviewPartIds = previewPartIds.ToArray()
                    };

                    callbackHandler.QueuePreviewPartIdUpdateRequest(request.Convert());
                });
        }

        private void onRequestReceived()
        {
            if (timeoutTimer == null)
            {
                timeoutTimer = new Timer(pingIntervalInSecs * 1000 * 1.2);
                timeoutTimer.AutoReset = true;
                timeoutTimer.Start();
                timeoutTimer.Elapsed += onTimeoutTimerElapsed;
            }
            else
            {
                timeoutTimer.Stop();
                timeoutTimer.Start();
            }
        }

        private void assembleMessageParts<T>(ref MessagePartInfo lastReceivedMessagePartInfo, ref List<T> receivedMessageParts, MessagePartInfo currentlyReceivedMessagePartInfo, T currentlyReceivedMessagePart, Action doCallback)
        {
            if (currentlyReceivedMessagePartInfo.NumberOfMessageParts == 1)
            {
                lastReceivedMessagePartInfo = currentlyReceivedMessagePartInfo;
                receivedMessageParts = new List<T>() { currentlyReceivedMessagePart };

                doCallback();

                lastReceivedMessagePartInfo = null;
                receivedMessageParts = null;
            }
            else
            {
                if (lastReceivedMessagePartInfo == null)
                {
                    lastReceivedMessagePartInfo = currentlyReceivedMessagePartInfo;
                    receivedMessageParts = new List<T>() { currentlyReceivedMessagePart };
                }
                else
                {
                    if (lastReceivedMessagePartInfo.MessageCorrelationId == currentlyReceivedMessagePartInfo.MessageCorrelationId && lastReceivedMessagePartInfo.NumberOfMessageParts == currentlyReceivedMessagePartInfo.NumberOfMessageParts)
                    {
                        lastReceivedMessagePartInfo = currentlyReceivedMessagePartInfo;
                        receivedMessageParts.Add(currentlyReceivedMessagePart);

                        if (lastReceivedMessagePartInfo.LastMessagePart && lastReceivedMessagePartInfo.NumberOfMessageParts == receivedMessageParts.Count)
                        {
                            doCallback();
                            lastReceivedMessagePartInfo = null;
                            receivedMessageParts = null;
                        }
                    }
                    else
                    {
                        lastReceivedMessagePartInfo = currentlyReceivedMessagePartInfo;
                        receivedMessageParts = null;
                    }
                }
            }
        }

        private void onTimeoutTimerElapsed(object sender, ElapsedEventArgs e)
        {
            lock (this)
            {
                onConnectionClosed();
                callbackHandler.QueueDisconnectRequest();
            }
        }

        private HttpSelfHostConfiguration getWebApiConfiguration()
        {
            var config = new HttpSelfHostConfiguration(baseAddress);

            config.Routes.MapHttpRoute(nameof(CallbackController.Ping), "", new { controller = "Callback", action = nameof(CallbackController.Ping) }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Get) });
            config.Routes.MapHttpRoute(nameof(CallbackController.UpdateContent), "content", new { controller = "Callback", action = nameof(CallbackController.UpdateContent) }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });
            config.Routes.MapHttpRoute(nameof(CallbackController.ChangeHighlight), "highlight", new { controller = "Callback", action = nameof(CallbackController.ChangeHighlight) }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });
            config.Routes.MapHttpRoute(nameof(CallbackController.UpdatePreviewPartIds), "previewpartids", new { controller = "Callback", action = nameof(CallbackController.UpdatePreviewPartIds) }, new { httpMethod = new HttpMethodConstraint(HttpMethod.Post) });

            config.MaxReceivedMessageSize = RestProtocolWrapper.MaxRequestSize;
            config.MaxBufferSize = RestProtocolWrapper.MaxRequestSize;

            config.MessageHandlers.Add(new CallbackServiceContextMessageHandler(this));

            return config;
        }
    }
}
