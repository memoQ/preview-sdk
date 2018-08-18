using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model
{
    public class ErrorDetails
    {
        /// <summary>
        /// This string uniquely identifies the problem.
        /// </summary>
        public string ErrorCode { get; set; }

        /// <summary>
        /// The detailed description of the problem.
        /// </summary>
        public string ErrorMessage { get; set; }
    }
}
