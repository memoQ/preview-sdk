using MemoQ.PreviewInterfaces;
using MemoQ.PreviewInterfaces.Entities;
using MemoQ.PreviewInterfaces.Exceptions;
using MemoQ.PreviewInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static MemoQ.WebPreview.Log.LogEntry;

namespace MemoQ.WebPreview
{
    internal class MainViewModel : ObservableViewModelBase
    {
        #region Fields

        public readonly WebPreviewCallbackHandler WebPreviewCallbackHandler;

        private readonly PreviewToolCallbackHandler previewToolCallbackHandler;

        /// <summary>
        /// The preview service proxy to communicate with memoQ
        /// </summary>
        private readonly PreviewServiceProxy previewServiceProxy;

        /// <summary>
        /// View model for connection related properties
        /// </summary>
        private readonly ConnectViewModel connectViewModel;

        private bool noContent;

        private bool waitingForRegistration;

        #endregion Fields

        #region Properties

        public ConnectViewModel ConnectViewModel
        {
            get { return connectViewModel; }
        }

        public bool NoContent
        {
            get { return noContent; }
            set
            {
                if (noContent != value)
                {
                    noContent = value;
                    OnPropertyChanged();
                }
            }
        }

        public bool WaitingForRegistration
        {
            get { return waitingForRegistration; }
            set
            {
                if (waitingForRegistration != value)
                {
                    waitingForRegistration = value;
                    OnPropertyChanged();
                }
            }
        }

        #endregion Properties

        #region Constructor

        public MainViewModel(Action<string> loadPageInBrowser, Action<string> executeJavaScriptCodeInBrowser, Action handleDisconnect)
        {
            Settings.Instance.LoadSettings();

            previewToolCallbackHandler = new PreviewToolCallbackHandler(
                (url) => { NoContent = false; WaitingForRegistration = true; loadPageInBrowser(url); },
                (javaScript) => { executeJavaScriptCodeInBrowser(javaScript); },
                (previewPartIds) => { requestContentUpdate(previewPartIds); },
                () => { requestPreviewPartIdUpdate(); },
                () => { handleDisconnect(); });

            try
            {
                previewServiceProxy = new PreviewServiceProxy(previewToolCallbackHandler, Settings.Instance.NamedPipeAddress, CommunicationProtocols.NamedPipe);
            }
            catch (PreviewServiceUnavailableException)
            {
                Log.Instance.WriteMessage(Log.PreviewUnavailableMessage, SeverityOption.Warning);
            }

            connectViewModel = new ConnectViewModel(previewServiceProxy, previewToolCallbackHandler);

            WebPreviewCallbackHandler = new WebPreviewCallbackHandler(connectViewModel);
            WebPreviewCallbackHandler.PreviewToolRegistrationReceived += onPreviewToolRegistrationReceivedFromWebApp;

            NoContent = true;
            WaitingForRegistration = false;
        }

        #endregion Constructor

        #region Public methods

        public void Connect()
        {
            ConnectViewModel.Connect();
        }

        public void Disconnect()
        {
            ConnectViewModel.Disconnect();
        }

        #endregion Public methods

        #region Private methods

        private void requestContentUpdate(string[] previewPartIds)
        {
            var requestStatus = connectViewModel.CallProxyMethod(() => connectViewModel.PreviewServiceProxy?.RequestContentUpdate(new ContentUpdateRequestFromPreviewTool(previewPartIds, null))).Result;
            if (requestStatus != null && !requestStatus.RequestAccepted)
                Log.Instance.WriteMessage($"Error occurred during requesting a content update from memoQ.\r\nError code: {requestStatus.ErrorCode}\r\nError message: {requestStatus.ErrorMessage}", Log.LogEntry.SeverityOption.Error);
        }

        private void requestPreviewPartIdUpdate()
        {
            var requestStatus = connectViewModel.CallProxyMethod(() => connectViewModel.PreviewServiceProxy?.RequestPreviewPartIdUpdate()).Result;
            if (requestStatus != null && !requestStatus.RequestAccepted)
                Log.Instance.WriteMessage($"Error occurred during requesting preview part id update from memoQ.\r\nError code: {requestStatus.ErrorCode}\r\nError message: {requestStatus.ErrorMessage}", Log.LogEntry.SeverityOption.Error);
        }

        private void onPreviewToolRegistrationReceivedFromWebApp(object sender, Regex e)
        {
            WaitingForRegistration = false;
            previewToolCallbackHandler.OnPreviewToolRegistrationReceivedFromWebApp(e);
        }

        #endregion Private methods
    }
}