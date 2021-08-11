using Newtonsoft.Json;

namespace dnMisp.Objects
{
    public class RelatedEvent : JsonMispObject
    {
        [JsonProperty("Event")]
        public MispEvent Event { get; set; }
        [JsonProperty("Org")]
        public Org Org { get; set; }
        [JsonProperty("OrgC")]
        public Org OrgC { get; set; }
    }
}
