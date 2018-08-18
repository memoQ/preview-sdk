using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model
{
    public class SourceDocument
    {
        /// <summary>
        /// The guid of the document containing the preview part.
        /// </summary>
        public Guid DocumentGuid { get; set; }

        /// <summary>
        /// The name of the document containing the preview part.
        /// </summary>
        public string DocumentName { get; set; }

        /// <summary>
        /// The import path of the document containing the preview part.
        /// </summary>
        public string ImportPath { get; set; }
    }
}
