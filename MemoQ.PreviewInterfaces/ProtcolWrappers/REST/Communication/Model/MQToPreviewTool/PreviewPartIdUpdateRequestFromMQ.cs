using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model
{
    public class PreviewPartIdUpdateRequestFromMQ
    {
        /// <summary>
        /// The preview part identifiers.
        /// </summary>
        public string[] PreviewPartIds { get; set; }
    }
}
