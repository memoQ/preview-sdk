using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.PreviewInterfaces.ProtcolWrappers.REST.Communication.Model
{
    public class PreviewProperty
    {
        /// <summary>
        /// The name of the property.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// The value of the property.
        /// </summary>
        public object Value { get; set; }
    }
}
