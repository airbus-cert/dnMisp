using Newtonsoft.Json;
using System.Collections.Generic;

namespace dnMisp.Objects
{
    public class MispAttributeList
    : JsonMispObject
    {

        [JsonProperty("attribute")]
        public List<Attribute> Attributes { get; set; }
    }
}
