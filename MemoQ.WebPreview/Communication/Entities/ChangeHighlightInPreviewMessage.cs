using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.WebPreview
{
    public class ChangeHighlightInPreviewMessage : PreviewMessage
    {
        private const string messageType = "ChangeHighlightInPreview";

        public ChangeHighlightInPreviewMessage(ChangeHighlightInPreviewParams parameters)
            : base(messageType, parameters)
        { }
    }
}
