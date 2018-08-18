using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.Entities
{
    public class ContentUpdateRequestFromMQ
    {
        /// <summary>
        /// The preview parts.
        /// </summary>
        public readonly PreviewPart[] PreviewParts;

        public ContentUpdateRequestFromMQ(PreviewPart[] previewParts)
        {
            PreviewParts = previewParts;
        }
    }
}
