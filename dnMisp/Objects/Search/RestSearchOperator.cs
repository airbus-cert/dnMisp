using Newtonsoft.Json;

namespace dnMisp.Objects
{
    public class RestSearchOperator<T>
    {
        [JsonProperty("OR")]
        public RestSearchOperatorList<T> Or { get; set; } = new RestSearchOperatorList<T>();

        [JsonProperty("NOT")]
        public RestSearchOperatorList<T> Not { get; set; } = new RestSearchOperatorList<T>();
    }
}
