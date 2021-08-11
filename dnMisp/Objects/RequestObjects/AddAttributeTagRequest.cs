using Newtonsoft.Json;

namespace dnMisp.Objects
{
    public class AddAttributeTagRequest
        : JsonMispObject
    {
        [JsonProperty("Attribute")]
        public AddTagRequest Attribute { get; set; }
    }
}
