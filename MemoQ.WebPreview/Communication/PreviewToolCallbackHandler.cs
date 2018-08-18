using CefSharp;
using MemoQ.PreviewInterfaces;
using MemoQ.PreviewInterfaces.Entities;
using MemoQ.PreviewInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace MemoQ.WebPreview
{
    internal class PreviewToolCallbackHandler : IPreviewToolCallback
    {
        private readonly Action<string> handlePreviewUrlChange;
        private readonly Action<string> executeJavaScriptAsync;
        private readonly Action<string[]> requestContentUpdate;
        private readonly Action requestPreviewPartIdUpdate;
        private readonly Action handleDisconnect;

        private string externalToolAddress;
        private Regex previewPartIdRegex;
        private ContentUpdateRequestFromMQ lastContentUpdateRequest;
        private ChangeHighlightRequestFromMQ lastChangeHighlightRequest;

        public PreviewToolCallbackHandler(Action<string> handlePreviewUrlChange, Action<string> executeJavaScriptAsync, Action<string[]> requestContentUpdate, Action requestPreviewPartIdUpdate, Action handleDisconnect)
        {
            this.handlePreviewUrlChange = handlePreviewUrlChange;
            this.executeJavaScriptAsync = executeJavaScriptAsync;
            this.requestContentUpdate = requestContentUpdate;
            this.requestPreviewPartIdUpdate = requestPreviewPartIdUpdate;
            this.handleDisconnect = handleDisconnect;
        }

        public void HandleContentUpdateRequest(ContentUpdateRequestFromMQ contentUpdateRequest)
        {
            lock (this)
            {
                if (externalToolAddress == null)
                {
                    foreach (var previewPart in contentUpdateRequest.PreviewParts)
                    {
                        if (updateExternalToolAddress(previewPart.PreviewProperties))
                            break;
                    }
                }

                if (previewPartIdRegex != null)
                {
                    var contentUpdateParams = contentUpdateRequest.ConvertRequestToContentUpdateParams(previewPartIdRegex);
                    if (contentUpdateParams.PreviewParts.Length > 0)
                    {
                        var postMessage = new ContentUpdateMessage(contentUpdateParams).SerializeToPostMessage();
                        executeJavaScriptAsync(postMessage);
                    }

                    if (lastChangeHighlightRequest != null)
                    {
                        var changeHighlightParams = lastChangeHighlightRequest.ConvertRequestToChangeHighlightParams(previewPartIdRegex);
                        if (changeHighlightParams.ActivePreviewParts.Length > 0)
                        {
                            var postMessage = new ChangeHighlightInPreviewMessage(changeHighlightParams).SerializeToPostMessage();
                            executeJavaScriptAsync(postMessage);
                            lastChangeHighlightRequest = null;
                        }
                    }
                }
                else
                    lastContentUpdateRequest = contentUpdateRequest;
            }
        }

        public void HandleChangeHighlightRequest(ChangeHighlightRequestFromMQ changeHighlighRequest)
        {
            lock (this)
            {
                updateExternalToolAddress(changeHighlighRequest.ActivePreviewParts[0].PreviewProperties);

                if (previewPartIdRegex != null)
                {
                    var changeHighlightParams = changeHighlighRequest.ConvertRequestToChangeHighlightParams(previewPartIdRegex);
                    if (changeHighlightParams.ActivePreviewParts.Length > 0)
                    {
                        var postMessage = new ChangeHighlightInPreviewMessage(changeHighlightParams).SerializeToPostMessage();
                        executeJavaScriptAsync(postMessage);
                    }
                }
                else
                    lastChangeHighlightRequest = changeHighlighRequest;
            }
        }

        public void HandlePreviewPartIdUpdateRequest(PreviewPartIdUpdateRequestFromMQ previewPartIdUpdateRequest)
        {
            if (previewPartIdUpdateRequest.PreviewPartIds.Length > 0)
                requestContentUpdate(previewPartIdUpdateRequest.PreviewPartIds);
        }

        public void HandleDisconnect()
        {
            lock (this)
            {
                externalToolAddress = null;
                previewPartIdRegex = null;
                lastContentUpdateRequest = null;
                lastChangeHighlightRequest = null;
                handleDisconnect();
            }
        }

        public void OnPreviewToolRegistrationReceivedFromWebApp(Regex regex)
        {
            lock (this)
            {
                previewPartIdRegex = regex;

                if (lastContentUpdateRequest != null)
                {
                    var contentUpdateParams = lastContentUpdateRequest.ConvertRequestToContentUpdateParams(previewPartIdRegex);
                    if (contentUpdateParams.PreviewParts.Length > 0)
                    {
                        var postMessage = new ContentUpdateMessage(contentUpdateParams).SerializeToPostMessage();
                        executeJavaScriptAsync(postMessage);
                        lastContentUpdateRequest = null;
                    }

                    if (lastChangeHighlightRequest != null)
                    {
                        var changeHighlightParams = lastChangeHighlightRequest.ConvertRequestToChangeHighlightParams(previewPartIdRegex);
                        if (changeHighlightParams.ActivePreviewParts.Length > 0)
                        {
                            var postMessage = new ChangeHighlightInPreviewMessage(changeHighlightParams).SerializeToPostMessage();
                            executeJavaScriptAsync(postMessage);
                            lastChangeHighlightRequest = null;
                        }
                    }
                }
                else
                    requestPreviewPartIdUpdate();
            }
        }

        private bool updateExternalToolAddress(PreviewProperty[] previewProperties)
        {
            for (int i = 0; i < previewProperties.Length; i++)
            {
                if (previewProperties[i].Name == PropertyNames.WebPreviewBaseUrl)
                {
                    if (externalToolAddress != (string)previewProperties[i].Value)
                    {
                        externalToolAddress = (string)previewProperties[i].Value;
                        previewPartIdRegex = null;
                        lastContentUpdateRequest = null;
                        lastChangeHighlightRequest = null;

                        handlePreviewUrlChange(externalToolAddress);
                        return true;
                    }

                    return false;
                }
            }

            return false;
        }
    }
}
