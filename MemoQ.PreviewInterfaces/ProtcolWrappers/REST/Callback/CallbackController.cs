using MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model;
using Newtonsoft.Json;
using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Callback
{
    public class CallbackController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Ping()
        {
            getCallbackHandler().HandlePingRequest();
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage UpdateContent(ContentUpdateRequestFromMQ request)
        {
            getCallbackHandler().HandleContentUpdateRequest(request, getMessagePartInfo());
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage ChangeHighlight(ChangeHighlightRequestFromMQ request)
        {
            getCallbackHandler().HandleChangeHighlightRequest(request, getMessagePartInfo());
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        [HttpPost]
        public HttpResponseMessage UpdatePreviewPartIds(PreviewPartIdUpdateRequestFromMQ request)
        {
            getCallbackHandler().HandlePreviewPartIdUpdateRequest(request, getMessagePartInfo());
            return new HttpResponseMessage(HttpStatusCode.OK);
        }

        private ICallbackHandler getCallbackHandler()
        {
            return CallbackServiceContext.GetCallbackHandler(Request);
        }

        private MessagePartInfo getMessagePartInfo()
        {
            Guid messageCorrelationId;
            int numberOfMessageParts;
            bool lastMessage;

            if (!Request.Headers.Contains(RestProtocolWrapper.MessageCorrelationIdHttpHeaderName) ||
                !Guid.TryParse(Request.Headers.GetValues(RestProtocolWrapper.MessageCorrelationIdHttpHeaderName).First(), out messageCorrelationId) ||
                !Request.Headers.Contains(RestProtocolWrapper.NumberOfMessagePartsHttpHeaderName) ||
                !int.TryParse(Request.Headers.GetValues(RestProtocolWrapper.NumberOfMessagePartsHttpHeaderName).First(), out numberOfMessageParts) ||
                !Request.Headers.Contains(RestProtocolWrapper.LastMessageHttpHeaderName) ||
                !bool.TryParse(Request.Headers.GetValues(RestProtocolWrapper.LastMessageHttpHeaderName).First(), out lastMessage))
            {
                messageCorrelationId = Guid.NewGuid();
                numberOfMessageParts = 1;
                lastMessage = true;
            }

            return new MessagePartInfo(messageCorrelationId, numberOfMessageParts, lastMessage);
        }
    }
}
