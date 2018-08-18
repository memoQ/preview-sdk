using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class PreviewPartIdUpdateRequestFromPreviewToolParameters
    {
        /// <summary>
        /// The unique identifier of the preview tool.
        /// </summary>
        public Guid PreviewToolId;
    }
}
