using Newtonsoft.Json;
using System;

namespace dnMisp.Objects
{
    public class Galaxy
        : JsonMispObject
    {
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("uuid")]
        public Guid UUID { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("type")]
        public string Type { get; set; }

        [JsonProperty("description")]
        public string Description { get; set; }

        [JsonProperty("version")]
        public string Version { get; set; }

        [JsonProperty("icon")]
        public string Icon { get; set; }

        [JsonProperty("namespace")]
        public string Namespace { get; set; }

        [JsonProperty("GalaxyCluster")]
        public GalaxyCluster[] Clusters { get; set; }
    }
}
