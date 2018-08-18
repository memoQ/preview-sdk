using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model
{
    public class PreviewPart
    {
        /// <summary>
        /// The identifier of the preview part.
        /// </summary>
        public string PreviewPartId { get; set; }

        /// <summary>
        /// The preview properties.
        /// </summary>
        public PreviewProperty[] PreviewProperties { get; set; }

        /// <summary>
        /// The source document containing the preview part.
        /// </summary>
        public SourceDocument SourceDocument { get; set; }

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
        public PreviewContent SourceContent { get; set; }

        /// <summary>
        /// The target content of the preview part.
        /// </summary>
        public PreviewContent TargetContent { get; set; }
    }
}
