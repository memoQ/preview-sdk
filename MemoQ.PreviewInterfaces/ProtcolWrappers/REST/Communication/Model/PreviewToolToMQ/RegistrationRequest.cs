using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model
{
    public class RegistrationRequest
    {
        /// <summary>
        /// The unique identifier of the preview tool.
        /// </summary>
        public Guid PreviewToolId { get; set; }

        /// <summary>
        /// The name of the preview tool.
        /// </summary>
        public string PreviewToolName { get; set; }

        /// <summary>
        /// The description of the preview tool.
        /// </summary>
        public string PreviewToolDescription { get; set; }

        /// <summary>
        /// The automatic startup command line that will be used to start the preview tool automatically.
        /// The tool will not be started automatically by memoQ if this field is not specified.
        /// </summary>
        public string AutoStartupCommand { get; set; }

        /// <summary>
        /// The regular expression is used to check if the stored preview identifier of the content
        /// belongs to the preview tool at hand or not.
        /// </summary>
        public string PreviewPartIdRegex { get; set; }

        /// <summary>
        /// Indicates whether the preview tool requires the base url of the web preview.
        /// </summary>
        public bool RequiresWebPreviewBaseUrl { get; set; }

        /// <summary>
        /// The complexity level of the offered text when memoQ sends it to the tool. 
        /// </summary>
        public ContentComplexityLevel ContentComplexity { get; set; }

        /// <summary>
        /// The names of the required properties.
        /// </summary>
        public string[] RequiredProperties { get; set; }
    }
}
