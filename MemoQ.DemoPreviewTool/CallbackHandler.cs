using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MemoQ.PreviewInterfaces.Entities;
using MemoQ.PreviewInterfaces.Interfaces;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace MemoQ.DemoPreviewTool
{
    internal class CallbackHandler : IPreviewToolCallback
    {
        private readonly Action onPreviewToolDisconnected;
        private readonly JsonSerializerSettings jsonSerializerSettings;

        public CallbackHandler(Action onPreviewToolDisconnected)
        {
            this.onPreviewToolDisconnected = onPreviewToolDisconnected;

            jsonSerializerSettings = new JsonSerializerSettings();
            jsonSerializerSettings.Converters.Add(new StringEnumConverter());
        }

        public void HandleContentUpdateRequest(ContentUpdateRequestFromMQ contentUpdateRequest)
        {
            logRequest("Content update request", contentUpdateRequest);
        }

        public void HandleChangeHighlightRequest(ChangeHighlightRequestFromMQ changeHighlighRequest)
        {
            logRequest("Change highlight request", changeHighlighRequest);
        }

        public void HandlePreviewPartIdUpdateRequest(PreviewPartIdUpdateRequestFromMQ previewPartIdUpdateRequest)
        {
            logRequest("Preview part id update request", previewPartIdUpdateRequest);
        }

        public void HandleDisconnect()
        {
            onPreviewToolDisconnected();
        }

        private void logRequest(string requestType, object request)
        {
            Log.Instance.WriteMessage($"[MessageFromMemoQ] - {requestType} received:");
            Log.Instance.WriteMessage(JsonConvert.SerializeObject(request, Formatting.Indented, jsonSerializerSettings));
        }
    }
}
