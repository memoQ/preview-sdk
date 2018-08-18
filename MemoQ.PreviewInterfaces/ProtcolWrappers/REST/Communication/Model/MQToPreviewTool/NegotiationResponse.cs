using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model
{
    public class NegotiationResponse
    {
        /// <summary>
        /// The connection key the preview tool has to use if sending requests.
        /// </summary>
        public string ConnectionKey { get; set; }

        /// <summary>
        /// The protocol version to be used.
        public string ProtocolVersion { get; set; }
    }
}
