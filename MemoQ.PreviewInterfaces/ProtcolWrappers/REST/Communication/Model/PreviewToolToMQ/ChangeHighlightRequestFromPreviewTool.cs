using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model
{
    public class ChangeHighlightRequestFromPreviewTool
    {
        /// <summary>
        /// The identifier of the preview part.
        /// </summary>
        public string PreviewPartId { get; set; }

        /// <summary>
        /// The source language of the preview part.
        /// </summary>
        public string SourceLangCode { get; set; }

        /// <summary>
        /// The target language of the preview part.
        /// </summary>
        public string TargetLangCode { get; set; }

        /// <summary>
        /// The source content of the preview part.
        /// </summary>
        public string SourceContent { get; set; }

        /// <summary>
        /// The target content of the preview part.
        /// </summary>
        public string TargetContent { get; set; }

        /// <summary>
        /// The focused range on the source side.
        /// </summary>
        public FocusedRange SourceFocusedRange { get; set; }

        /// <summary>
        /// The focused range on the target side.
        /// </summary>
        public FocusedRange TargetFocusedRange { get; set; }
    }
}
