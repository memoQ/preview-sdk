using MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Callback
{
    internal interface ICallbackHandler
    {
        void HandlePingRequest();
        void HandleContentUpdateRequest(ContentUpdateRequestFromMQ contentUpdateRequest, MessagePartInfo messagePartInfo);
        void HandleChangeHighlightRequest(ChangeHighlightRequestFromMQ changeHighlighRequest, MessagePartInfo messagePartInfo);
        void HandlePreviewPartIdUpdateRequest(PreviewPartIdUpdateRequestFromMQ previewPartIdUpdateRequest, MessagePartInfo messagePartInfo);
    }
}
