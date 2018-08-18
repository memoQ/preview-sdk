using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.WebPreview
{
    public class PreviewToolPreviewPart
    {
        public readonly string PreviewPartId;
        public readonly string SourceLangCode;
        public readonly string TargetLangCode;
        public readonly string SourceContent;
        public readonly string TargetContent;

        public PreviewToolPreviewPart(string previewPartId, string sourceLangCode, string targetLangCode, string sourceContent, string targetContent)
        {
            PreviewPartId = previewPartId;
            SourceLangCode = sourceLangCode;
            TargetLangCode = targetLangCode;
            SourceContent = sourceContent;
            TargetContent = targetContent;
        }
    }
}
