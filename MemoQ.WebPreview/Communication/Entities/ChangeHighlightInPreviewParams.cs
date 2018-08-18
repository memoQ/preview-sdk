
using MemoQ.PreviewInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.WebPreview
{
    public class ChangeHighlightInPreviewParams : PreviewMessageParams
    {
        public readonly PreviewToolPreviewPartWithFocusedRange[] ActivePreviewParts;

        public ChangeHighlightInPreviewParams(PreviewToolPreviewPartWithFocusedRange[] activePreviewParts)
        {
            ActivePreviewParts = activePreviewParts;
        }
    }
}
