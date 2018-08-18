using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class ContentUpdateRequestFromPreviewToolParameters
    {
        /// <summary>
        /// The unique identifier of the preview tool.
        /// </summary>
        public Guid PreviewToolId;

        /// <summary>
        /// The requested preview part ids.
        /// </summary>
        public string[] PreviewPartIds;

        /// <summary>
        /// The target language codes.
        /// </summary>
        public string[] TargetLangCodes;
    }
}
