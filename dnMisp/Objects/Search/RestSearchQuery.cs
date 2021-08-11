using dnMisp.Misc;
using Newtonsoft.Json;
using System;
using System.Text;

namespace dnMisp.Objects
{
    public enum RestSearchResultType
    {
        json,
        xml,
        csv,
    }

    public class RestSearchQuery
        : JsonBaseObject
    {
        [JsonRequired]
        [JsonProperty("returnFormat")]
        public RestSearchResultType ReturnFormat { get; set; } = RestSearchResultType.json;

        [JsonProperty("limit")]
        public uint? Limit { get; set; }

        [JsonProperty("page")]
        public uint? Page { get; set; }

        [JsonProperty("value")]
        public string Value { get; set; }

        [JsonProperty("category")]
        public string Category { get; set; }

        [JsonProperty("org")]
        public string Organization { get; set; }

        [JsonProperty("type")]
        public RestSearchOperator<string> Type { get; set; }

        [JsonProperty("quickFilter")]
        public bool? QuickFilter { get; set; }

        [JsonConverter(typeof(RestSearchDateTimeConverter))]
        [JsonProperty("from")]
        public DateTime? FromDate { get; set; }

        [JsonConverter(typeof(RestSearchDateTimeConverter))]
        [JsonProperty("to")]
        public DateTime? ToDate { get; set; }

        [JsonProperty("last")]
        public string Last { get; set; }

        [JsonProperty("eventid")]
        public RestSearchOperator<uint> EventIds { get; set; }

        [JsonProperty("withAttachments")]
        public bool? WithAttachments { get; set; }

        [JsonProperty("metadata")]
        public bool? MetaData { get; set; }

        [JsonProperty("tags")]
        public RestSearchOperator<string> Tags { get; set; }

        [JsonProperty("published")]
        public bool? Published { get; set; }

        [JsonProperty("to_ids")]
        public bool? ToIDS { get; set; }

        [JsonProperty("deleted")]
        public bool? Deleted { get; set; }

        [JsonProperty("includeEventUuid")]
        public bool? IncludeEventUuid { get; set; }

        [JsonProperty("sgReferenceOnly")]
        public bool? ShadowGroupReferenceOnly { get; set; }
    }
}
