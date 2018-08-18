using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    internal class PreviewPartIdUpdateRequestFromMQParameters
    {
        /// <summary>
        /// The preview part identifiers.
        /// </summary>
        public string[] PreviewPartIds;
    }
}
