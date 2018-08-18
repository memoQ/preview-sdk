using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model
{
    public class ContentUpdateRequestFromMQ
    {
        /// <summary>
        /// The preview parts.
        /// </summary>
        public PreviewPart[] PreviewParts { get; set; }
    }
}
