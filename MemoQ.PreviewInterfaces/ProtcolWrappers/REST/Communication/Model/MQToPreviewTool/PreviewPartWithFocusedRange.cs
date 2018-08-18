using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model
{
    public class PreviewPartWithFocusedRange : PreviewPart
    {
        /// <summary>
        /// The focused range on the source side.
        /// </summary>
        public FocusedRange SourceFocusedRange { get; set; }

        /// <summary>
        /// The focused range on the target side.
        /// </summary>
        public FocusedRange TargetFocusedRange { get; set; }
    }
}
