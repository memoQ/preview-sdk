using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class RequestRefusedParameters
    {
        /// <summary>
        /// The type of the refused command.
        /// </summary>
        public string CommandType;

        /// <summary>
        /// The cause if the request has been refused.
        /// </summary>
        public string ErrorCode;

        /// <summary>
        /// The error message describing the problem.
        /// </summary>
        public string ErrorMessage;
    }
}
