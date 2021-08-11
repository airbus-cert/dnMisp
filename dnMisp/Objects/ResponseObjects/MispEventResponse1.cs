using Newtonsoft.Json;
using System.Collections.Generic;

namespace dnMisp.Objects
{
    public class MispEventSearchResponseItem
        : JsonMispObject
    {

        [JsonProperty("Event")]
        public MispEvent Event { get; set; }
    }
    public class MispEventSearchResponse
        : JsonMispObject
    {

        [JsonProperty("response")]
        public List<MispEventSearchResponseItem> Response { get; set; }
    }
}
