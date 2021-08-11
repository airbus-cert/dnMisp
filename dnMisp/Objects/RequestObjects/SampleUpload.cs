using Newtonsoft.Json;

namespace dnMisp.Objects
{
    public class SampleUpload
        : JsonMispObject
    {
        [JsonProperty("request")]
        public SampleUploadRequest SampleUploadRequest { get; set; }

    }
}
