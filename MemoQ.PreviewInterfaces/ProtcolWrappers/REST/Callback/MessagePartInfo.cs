using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Callback
{
    internal class MessagePartInfo
    {
        /// <summary>
        /// The correlation identifier of the message.
        /// </summary>
        public readonly Guid MessageCorrelationId;

        /// <summary>
        /// Gets the number of the parts of te original message.
        /// </summary>
        public readonly int NumberOfMessageParts;

        /// <summary>
        /// Indicates whether the current message is the last part of the original message.
        /// </summary>
        public readonly bool LastMessagePart;

        public MessagePartInfo(Guid messageCorrelationId, int numberOfMessageParts, bool lastMessagePart)
        {
            MessageCorrelationId = messageCorrelationId;
            NumberOfMessageParts = numberOfMessageParts;
            LastMessagePart = lastMessagePart;
        }
    }
}
