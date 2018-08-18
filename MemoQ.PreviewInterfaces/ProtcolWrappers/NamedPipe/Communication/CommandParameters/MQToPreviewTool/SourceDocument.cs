using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class SourceDocument
    {
        /// <summary>
        /// The guid of the document containing the preview part.
        /// </summary>
        public Guid DocumentGuid;

        /// <summary>
        /// The name of the document containing the preview part.
        /// </summary>
        public string DocumentName;

        /// <summary>
        /// The import path of the document containing the preview part.
        /// </summary>
        public string ImportPath;
    }
}
