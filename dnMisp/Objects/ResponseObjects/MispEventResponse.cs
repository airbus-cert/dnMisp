using dnMisp.Misc;
using Newtonsoft.Json;

namespace dnMisp.Objects
{
    public class MispEventResponse
        : JsonMispObject
    {
        [JsonProperty("Event")]
        public MispEvent Event { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("message")]
        public string Message { get; set; }

        [JsonProperty("url")]
        public string Url { get; set; }

        [JsonProperty("errors")]
        public string Errors { get; set; }

        public MispEventResponse(MispEvent evnt)
        {
            Event = evnt;
        }
    }
}
