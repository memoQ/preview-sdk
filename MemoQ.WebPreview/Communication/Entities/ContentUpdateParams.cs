using MemoQ.PreviewInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.WebPreview
{
    public class ContentUpdateParams : PreviewMessageParams
    {
        public readonly PreviewToolPreviewPart[] PreviewParts;

        public ContentUpdateParams(PreviewToolPreviewPart[] previewParts)
        {
            PreviewParts = previewParts;
        }
    }
}
