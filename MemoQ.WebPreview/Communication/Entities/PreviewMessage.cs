using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MemoQ.WebPreview
{
    public class PreviewMessage
    {
        [JsonProperty(PropertyName = "type")]
        public string Type
        {
            get;
        }

        [JsonProperty(PropertyName = "params")]
        public PreviewMessageParams Params
        {
            get;
        }

        public PreviewMessage(string Type, PreviewMessageParams Params)
        {
            this.Type = Type;
            this.Params = Params;
        }

        public string SerializeToPostMessage()
        {
            string message =  JsonConvert.SerializeObject(this, new JsonSerializerSettings
            {
                ContractResolver = new CamelCasePropertyNamesContractResolver()
            });

            return $@"window.postMessage({message}, ""*"");";
        }
    }
}
