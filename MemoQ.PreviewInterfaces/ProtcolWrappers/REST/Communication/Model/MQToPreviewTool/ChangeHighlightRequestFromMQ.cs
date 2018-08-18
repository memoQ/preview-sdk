using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model
{
    public class ChangeHighlightRequestFromMQ
    {
        /// <summary>
        /// The active preview parts.
        /// </summary>
        public PreviewPartWithFocusedRange[] ActivePreviewParts { get; set; }
    }
}
