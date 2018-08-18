using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model
{
    public class PreviewContent
    {
        /// <summary>
        /// The complexity of the preview content.
        /// </summary>
        public ContentComplexityLevel Complexity { get; set; }

        /// <summary>
        /// The preview content.
        /// </summary>
        public string Content { get; set; }
    }
}
