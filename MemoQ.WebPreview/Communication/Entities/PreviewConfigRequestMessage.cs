using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.WebPreview
{
    public class PreviewConfigRequestMessage : PreviewMessage
    {
        private const string messageType = "PreviewConfigRequest";

        public PreviewConfigRequestMessage()
            : base(messageType, null)
        { }
    }
}
