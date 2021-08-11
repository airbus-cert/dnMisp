using Newtonsoft.Json;

namespace dnMisp.Objects
{
    public class AddEventTagRequest
        : JsonMispObject
    {
        [JsonProperty("Event")]
        public AddTagRequest Event { get; set; }
    }
}
