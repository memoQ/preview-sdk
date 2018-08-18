using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model
{
    public class ChangeRuntimeSettingsRequest
    {
        /// <summary>
        /// The complexity of the preview content.
        /// </summary>
        public ContentComplexityLevel ContentComplexity { get; set; }

        /// <summary>
        /// The names of the required properties.
        /// </summary>
        public string[] RequiredProperties { get; set; }
    }
}
