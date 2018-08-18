using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.NamedPipe.Communication.CommandParameters
{
    [Serializable]
    public class FocusedRange
    {
        /// <summary>
        /// The start index of the focused range.
        /// </summary>
        public int StartIndex;

        /// <summary>
        /// The length of the focused range.
        /// </summary>
        public int Length;
    }
}
