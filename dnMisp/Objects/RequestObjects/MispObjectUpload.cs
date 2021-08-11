using Newtonsoft.Json;
using System.Collections.Generic;

namespace dnMisp.Objects
{
    public class MispObjectUpload
        : JsonMispObject
    {

        [JsonProperty("Object")]
        public MispObject Object { get; set; }


        [JsonProperty("Attribute")]
        public List<Attribute> Attributes { get; set; } = new List<Attribute>();

    }
}
