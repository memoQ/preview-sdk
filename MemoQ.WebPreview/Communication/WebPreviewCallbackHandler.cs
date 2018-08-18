using MemoQ.PreviewInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MemoQ.WebPreview
{
    internal class WebPreviewCallbackHandler
    {
        private readonly ConnectViewModel connectViewModel;

        private const string PreviewConfigResponseMessageType = "PreviewConfigResponse";
        private const string ContentUpdateRequestMessageType = "ContentUpdateRequest";
        private const string ChangeHighlightRequestMessageType = "ChangeHighlightInMQ";
        private const string PreviewPartIdUpdateRequestMessageType = "PreviewPartIdUpdateRequest";

        public event EventHandler<Regex> PreviewToolRegistrationReceived;

        public WebPreviewCallbackHandler(ConnectViewModel connectViewModel)
        {
            this.connectViewModel = connectViewModel;
        }

        public void CallbackFunc(Object message)
        {
            var messageDictionary = (Dictionary<String, Object>)message;
            object type;
            messageDictionary.TryGetValue("type", out type);

            switch ((string)type)
            {
                case PreviewConfigResponseMessageType:
                    handleRegister(messageDictionary);
                    break;
                case ContentUpdateRequestMessageType:
                    handleRequestContentUpdate(messageDictionary);
                    break;
                case ChangeHighlightRequestMessageType:
                    handleRequestHighlightChange(messageDictionary);
                    break;
                case PreviewPartIdUpdateRequestMessageType:
                    handleRequestPreviewPartIdUpdate(messageDictionary);
                    break;
                default:
                    return;
            }
        }

        private void handleRegister(Dictionary<String, Object> message)
        {
            Guid previewToolId;
            Dictionary<String, Object> parameters;
            parcelMessage(message, out previewToolId, out parameters);

            object regex;
            if (parameters.TryGetValue("previewPartIdRegex", out regex))
            {
                PreviewToolRegistrationReceived?.Invoke(this, new Regex(regex.ToString()));

                var requestStatus = connectViewModel.CallProxyMethod(() => connectViewModel.PreviewServiceProxy?.RequestRuntimeSettingsChange(parameters.ConvertToChangeRuntimeSettingsRequest())).Result;
                if (!requestStatus.RequestAccepted)
                {
                    Log.Instance.WriteMessage($"Error occurred during the registration of the web-based preview.\r\n\r\nError code: {requestStatus.ErrorCode}\r\nError message: {requestStatus.ErrorMessage}", Log.LogEntry.SeverityOption.Error);
                    return;
                }
            }
        }

        private void handleRequestContentUpdate(Dictionary<String, Object> message)
        {
            Guid previewToolId;
            Dictionary<String, Object> parameters;
            parcelMessage(message, out previewToolId, out parameters);
            var requestStatus = connectViewModel.CallProxyMethod(() => connectViewModel.PreviewServiceProxy?.RequestContentUpdate(parameters.ConvertToContentUpdateRequest())).Result;
            if (!requestStatus.RequestAccepted)
                Log.Instance.WriteMessage($"Error occurred during requesting a content update from memoQ.\r\nError code: {requestStatus.ErrorCode}\r\nError message: {requestStatus.ErrorMessage}", Log.LogEntry.SeverityOption.Error);
            else
                Log.Instance.WriteMessage("Content update request was accepted by memoQ.", Log.LogEntry.SeverityOption.Info);
        }

        private void handleRequestHighlightChange(Dictionary<String, Object> message)
        {
            Guid previewToolId;
            Dictionary<String, Object> parameters;
            parcelMessage(message, out previewToolId, out parameters);
            var requestStatus = connectViewModel.CallProxyMethod(() => connectViewModel.PreviewServiceProxy?.RequestHighlightChange(parameters.ConvertToChangeHighlightRequest())).Result;
            if (!requestStatus.RequestAccepted)
                Log.Instance.WriteMessage($"Error occurred during requesting a highlight change memoQ.\r\nError code: {requestStatus.ErrorCode}\r\nError message: {requestStatus.ErrorMessage}", Log.LogEntry.SeverityOption.Error);
            else
                Log.Instance.WriteMessage("Content update request was accepted by memoQ.", Log.LogEntry.SeverityOption.Info);
        }

        private void handleRequestPreviewPartIdUpdate(Dictionary<String, Object> message)
        {
            Guid previewToolId;
            Dictionary<String, Object> parameters;
            parcelMessage(message, out previewToolId, out parameters);
            var requestStatus = connectViewModel.CallProxyMethod(() => connectViewModel.PreviewServiceProxy?.RequestPreviewPartIdUpdate()).Result;
            if (!requestStatus.RequestAccepted)
                Log.Instance.WriteMessage($"Error occurred during requesting preview part id update from memoQ.\r\nError code: {requestStatus.ErrorCode}\r\nError message: {requestStatus.ErrorMessage}", Log.LogEntry.SeverityOption.Error);
            else
                Log.Instance.WriteMessage("Preview part id update request was accepted by memoQ.", Log.LogEntry.SeverityOption.Info);
        }

        private void parcelMessage(Dictionary<String, Object> message, out Guid previewToolId, out Dictionary<String, Object> parameters)
        {
            Object value;

            message.TryGetValue("previewToolId", out value);
            previewToolId = Guid.Parse((string)value);
            message.TryGetValue("params", out value);
            parameters = (Dictionary<String, Object>)value;
        }
    }
}
