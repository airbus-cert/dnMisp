using Newtonsoft.Json;

namespace dnMisp.Objects
{
    public class ShadowAttributeRequest
        : JsonMispObject
    {
        [JsonProperty("ShadowAttribute")]
        public Attribute ShadowAttribute { get; set; }
    }
}
