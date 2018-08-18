using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class InvalidRequestParameters
    {
        /// <summary>
        /// The original request.
        /// </summary>
        public PipeCommand OriginalRequest;

        /// <summary>
        /// The description of the problem.
        /// </summary>
        public string ErrorMessage;
    }
}
