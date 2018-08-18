using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model
{
    public class NegotiationRequest
    {
        /// <summary>
        /// The list of the protocol versions known by the preview tool.
        /// </summary>
        public string[] KnownProtocolVersions { get; set; }
    }
}
