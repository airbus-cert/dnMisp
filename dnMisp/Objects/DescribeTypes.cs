using Newtonsoft.Json;

namespace dnMisp.Objects
{
    internal class DescribeTypes
    {
        [JsonProperty("result")]
        public TypesResult Result { get; set; }
    }
}
