using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.WebPreview
{
    public class ContentUpdateMessage : PreviewMessage
    {
        private const string messageType = "ContentUpdate";

        public ContentUpdateMessage(ContentUpdateParams parameters)
            : base(messageType, parameters)
        { }
    }
}
