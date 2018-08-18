using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class RequestAcceptedParameters
    {
        /// <summary>
        /// The type of the accepted command.
        /// </summary>
        public string CommandType;
    }
}
