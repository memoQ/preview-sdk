using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model
{
    public class ConnectionResponse
    {
        /// <summary>
        /// The callback address where memoQ will try to send requests to the preview tool.
        /// </summary>
        public string CallbackAddress { get; set; }

        /// <summary>
        /// The ping interval in secundums.
        /// </summary>
        public int PingIntervalInSecs { get; set; }
    }
}
