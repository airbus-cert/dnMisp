using Newtonsoft.Json;

namespace dnMisp.Objects
{
    public class AddTagRequest
        : JsonMispObject
    {
        [JsonProperty("id")]
        public string EventId { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }
    }
}
