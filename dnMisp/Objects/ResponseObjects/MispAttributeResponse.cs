using Newtonsoft.Json;
using System.Collections.Generic;

namespace dnMisp.Objects
{
    public class MispAttributeResponse
        : JsonMispObject
    {

        [JsonProperty("response")]
        public List<MispAttributeList> Response { get; set; }
    }
}
