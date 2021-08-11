using dnMisp.Enums;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace dnMisp.Objects
{
    public class SampleUploadRequest : JsonMispObject
    {
        [JsonProperty("distribution")]
        public Distribution Distribution { get; set; }

        [JsonProperty("info")]
        public string Info { get; set; }

        [JsonProperty("analysis")]
        public string Analysis { get; set; }

        [JsonProperty("threat_level_id")]
        public ThreatLevel ThreatLevelId { get; set; }
        /// <summary>
        /// category represents the intent of what the attribute is describing as selected by the attribute creator, using a list of pre-defined attribute categories.
        /// </summary>
        [JsonProperty("category"), JsonRequired]
        public string Category { get; set; }

        /// <summary>
        /// to_ids represents whether the attribute is meant to be actionable. Actionable defined attributes that can be used in automated processes as a pattern for detection in Local or Network Intrusion Detection System, log analysis tools or even filtering mechanisms.
        /// </summary>
        [JsonProperty("to_ids")]
        public bool ToIDS { get; set; }

        /// <summary>
        /// comment is a contextual comment field.
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }

        [JsonProperty("advanced")]
        public bool Advanced { get; set; }

        [JsonProperty("breakOnDuplicate")]
        public bool BreakOnDuplicate { get; set; } = true;

        [JsonProperty("files")]
        public List<SampleFile> Files { get; set; }

    }
}
