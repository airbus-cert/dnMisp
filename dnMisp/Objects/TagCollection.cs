using Newtonsoft.Json;

namespace dnMisp.Objects
{
    [JsonObject]
    internal class TagCollection
        : JsonBaseObject
    {
        [JsonProperty("Tag")]
        public Tag[] Tags { get; set; }


        public TagCollection(Tag[] tags)
        {
            Tags = tags;
        }

    }
}
