using MemoQ.PreviewInterfaces;
using MemoQ.PreviewInterfaces.Entities;
using MemoQ.PreviewInterfaces.Exceptions;
using MemoQ.PreviewInterfaces.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using static MemoQ.WebPreview.Log.LogEntry;

namespace MemoQ.WebPreview
{
    public class ConnectViewModel : ObservableViewModelBase
    {
        #region Fields

        /// <summary>
        /// The preview service proxy to communicate with memoQ
        /// </summary>
        private PreviewServiceProxy previewServiceProxy;

        /// <summary>
        /// An interface that handles the callback methods called by memoQ
        /// </summary>
        private IPreviewToolCallback previewToolCallback;

        /// <summary>
        /// Whether the tool is connected to memoQ
        /// </summary>
        private bool isConnected;

        /// <summary>
        /// Whether the tool should automatically connect (to memoQ) on startup
        /// </summary>
        private bool autoConnectOnStartup;

        #endregion Fields

        #region Properties

        public bool IsConnected
        {
            get
            {
                return isConnected;
            }
            set
            {
                isConnected = value;
                OnPropertyChanged();

                if (!isConnected)
                {
                    previewServiceProxy?.Dispose();
                    previewServiceProxy = null;
                }
            }
        }

        public bool AutoConnectOnStartup
        {
            get
            {
                return autoConnectOnStartup;
            }
            set
            {
                autoConnectOnStartup = value;
                Settings.Instance.AutoConnect = autoConnectOnStartup;
                Settings.Instance.SaveSettings();
                OnPropertyChanged();
            }
        }

        public string WarningText => !IsConnected ? "This preview tool is not yet connected to your memoQ." : "";

        public string SuggestionText => !IsConnected ? $"Run memoQ and click on the \"Connect\" button here to connect the preview tool.{Environment.NewLine}" +
            "If the tool is connecting for the first time, switch to memoQ to accept registration." : "";

        public PreviewServiceProxy PreviewServiceProxy
        {
            get
            {
                if (previewServiceProxy != null)
                    return previewServiceProxy;
                try
                {
                    previewServiceProxy = new PreviewServiceProxy(previewToolCallback, Settings.Instance.NamedPipeAddress, CommunicationProtocols.NamedPipe);
                }
                catch (PreviewServiceUnavailableException)
                {
                    IsConnected = false;
                    Log.Instance.WriteMessage(Log.PreviewUnavailableMessage, SeverityOption.Warning);
                }
                return previewServiceProxy;
            }
        }

        #endregion Properties

        #region Constructor

        public ConnectViewModel(PreviewServiceProxy serviceProxy, IPreviewToolCallback callback)
        {
            previewServiceProxy = serviceProxy;
            previewToolCallback = callback;
            AutoConnectOnStartup = Settings.Instance.AutoConnect;
        }

        #endregion Constructor

        #region Public methods

        public async void Register()
        {
            var request = new RegistrationRequest(WebPreviewToolProperties.PreviewToolId, WebPreviewToolProperties.PreviewToolName,
                WebPreviewToolProperties.PreviewToolDescription, System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName,
                ".*", true, ContentComplexityLevel.Minimal, new string[] { PropertyNames.WebPreviewBaseUrl });

            var requestStatus = await CallProxyMethod(new Func<RequestStatus>(() => PreviewServiceProxy?.Register(request)));
            IsConnected = (requestStatus != null && requestStatus.RequestAccepted);
        }

        public async void Connect()
        {
            var requestStatus = await CallProxyMethod(new Func<RequestStatus>(() => PreviewServiceProxy?.ConnectAndRequestPreviewPartIdUpdate(WebPreviewToolProperties.PreviewToolId)));
            if (requestStatus != null && requestStatus.RequestAccepted)
                IsConnected = true;
            else
                // if connecting failed, try a register, as maybe the tool is connecting for the first time
                Register();
        }

        public async void Disconnect()
        {
            try
            {
                await CallProxyMethod(new Func<RequestStatus>(() => PreviewServiceProxy?.Disconnect()));
                PreviewServiceProxy?.Dispose();
            }
            catch (PreviewServiceUnavailableException)
            {
                // if memoQ is not available, the disconnect might fail
            }
            finally
            {
                previewServiceProxy = null;
                IsConnected = false;
            }
        }

        #endregion Public methods

        #region Properties -- Command

        private ICommand connectCommand;
        public ICommand ConnectCommand
        {
            get
            {
                return connectCommand ?? (connectCommand = new CommandHandler(() => executeConnect(), connectCanExecute()));
            }
        }

        #endregion Properties -- Command

        #region Commands -- CanExecute

        private bool connectCanExecute()
        {
            return !IsConnected;
        }

        #endregion Commands -- CanExecute

        #region Commands -- Execute

        private void executeConnect()
        {
            Connect();
        }

        #endregion Commands -- Execute

        #region Private methods

        /// <summary>
        /// Helper function to call proxy methods and handle PreviewServiceUnavailableException in one place.
        /// </summary>
        public async Task<RequestStatus> CallProxyMethod(Func<RequestStatus> proxyMethod)
        {
            try
            {
                return await Task.Run(() => proxyMethod());
            }
            catch (PreviewServiceUnavailableException)
            {
                IsConnected = false;
                Log.Instance.WriteMessage(Log.PreviewUnavailableMessage, SeverityOption.Warning);
            }
            catch (PreviewToolAlreadyConnectedException)
            {
                return RequestStatus.Success();
            }
            catch (Exception ex)
            {
                Log.Instance.WriteMessage($"Unexpected error occurred: {ex}", SeverityOption.Error);
            }
            return null;
        }

        #endregion Private methods
    }
}
