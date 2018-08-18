using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model
{
    public class ContentUpdateRequestFromPreviewTool
    {
        /// <summary>
        /// The requested preview part ids.
        /// </summary>
        public string[] PreviewPartIds { get; set; }

        /// <summary>
        /// The target language codes.
        /// </summary>
        public string[] TargetLangCodes { get; set; }
    }
}
