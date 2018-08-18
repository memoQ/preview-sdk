using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.Entities
{
    public class ChangeRuntimeSettingsRequest
    {
        /// <summary>
        /// The complexity of the preview content.
        /// </summary>
        public readonly ContentComplexityLevel ContentComplexity;

        /// <summary>
        /// The names of the required properties.
        /// </summary>
        public readonly string[] RequiredProperties;

        public ChangeRuntimeSettingsRequest(ContentComplexityLevel contentComplexity, string[] requiredProperties)
        {
            ContentComplexity = contentComplexity;
            RequiredProperties = requiredProperties;
        }
    }
}
