using MemoQ.PreviewInterfaces.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.WebPreview
{
    public class PreviewToolPreviewPartWithFocusedRange : PreviewToolPreviewPart
    {
        /// <summary>
        /// The focused range on the source side.
        /// </summary>
        public readonly FocusedRange SourceFocusedRange;

        /// <summary>
        /// The focused range on the target side.
        /// </summary>
        public readonly FocusedRange TargetFocusedRange;

        public PreviewToolPreviewPartWithFocusedRange(string previewPartId, string sourceLangCode, string targetLangCode, string sourceContent, string targetContent, FocusedRange sourceFocusedRange, FocusedRange targetFocusedRange)
            : base(previewPartId, sourceLangCode, targetLangCode, sourceContent, targetContent)
        {
            SourceFocusedRange = sourceFocusedRange;
            TargetFocusedRange = targetFocusedRange;
        }
    }
}
