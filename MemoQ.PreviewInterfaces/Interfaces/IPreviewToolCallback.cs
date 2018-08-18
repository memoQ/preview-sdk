using MemoQ.PreviewInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.Interfaces
{
    public interface IPreviewToolCallback
    {
        void HandleContentUpdateRequest(ContentUpdateRequestFromMQ contentUpdateRequest);
        void HandleChangeHighlightRequest(ChangeHighlightRequestFromMQ changeHighlighRequest);
        void HandlePreviewPartIdUpdateRequest(PreviewPartIdUpdateRequestFromMQ previewPartIdUpdateRequest);
        void HandleDisconnect();
    }
}
