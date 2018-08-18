using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model
{
    public class FocusedRange
    {
        /// <summary>
        /// The start index of the focused range.
        /// </summary>
        public int StartIndex { get; set; }

        /// <summary>
        /// The length of the focused range.
        /// </summary>
        public int Length { get; set; }
    }
}
