using Newtonsoft.Json;
using System;

namespace dnMisp.Objects
{
    public class GalaxyElement
        : JsonMispObject
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("galaxy_cluster_id")] public string GalaxyClusterId { get; set; }
        [JsonProperty("key")] public string Key { get; set; }
        [JsonProperty("value")] public string Value { get; set; }

    }
}
