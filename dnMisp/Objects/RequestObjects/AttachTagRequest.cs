using Newtonsoft.Json;
using System;

namespace dnMisp.Objects
{
    public class AttachTagRequest
        : JsonMispObject
    {
        [JsonProperty("uuid")]
        public Guid UUID { get; set; }

        [JsonProperty("tag")]
        public string Tag { get; set; }
    }
}
