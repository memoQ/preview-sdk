using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    internal class PreviewContent
    {
        /// <summary>
        /// The complexity of the preview content.
        /// </summary>
        public ContentComplexityLevel Complexity;

        /// <summary>
        /// The preview content.
        /// </summary>
        public string Content;
    }
}
