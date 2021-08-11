using Newtonsoft.Json;

namespace dnMisp.Objects
{
    public class SampleFile : JsonMispObject
    {
        [JsonProperty("filename")]
        public string Filename { get; set; }

        [JsonProperty("data")]
        public string Data { get; set; }
    }
}