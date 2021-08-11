using Newtonsoft.Json;

namespace dnMisp.Objects
{
    public class JsonMispRequest<T>
        : JsonMispObject
        where T : JsonMispObject
    {
        [JsonProperty("request")]
        public T RequestObject { get; set; }
    }
}
