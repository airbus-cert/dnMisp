using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace dnMisp.Objects
{
    internal class TypesResult 
        : JsonMispObject
    {
        [JsonProperty("sane_defaults")]
        public JObject SaneDefaults { get; set; }

        [JsonProperty("types")]
        public string[] Types { get; set; }

        [JsonProperty("categories")]
        public string[] Categories { get; set; }

        [JsonProperty("category_type_mappings")]
        public JObject CategoryTypeMappings { get; set; }
    }

}
