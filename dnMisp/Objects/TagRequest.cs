using Newtonsoft.Json;

namespace dnMisp.Objects
{
    [JsonObject]
    public class TagRequest : JsonMispObject
    {
        public TagRequest(Tag tag)
        {
            Tag = tag;
        }

        [JsonProperty("request"), JsonRequired]
        public Tag Tag { get; set; }
    }
}
