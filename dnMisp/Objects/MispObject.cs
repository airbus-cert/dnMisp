using dnMisp.Enums;
using dnMisp.Misc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;

namespace dnMisp.Objects
{
    public class MispObject 
        : JsonMispObject
    {

        /// <summary>
        /// id represents the human-readable identifier associated to the attribute for a specific MISP instance.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        [JsonProperty("name")]
        public string Name { get; set; }

        [JsonProperty("meta-category")]
        public string MetaCategory { get; set; }

        [JsonProperty("event_id")]
        public int? EventId { get; set; }



        /// <summary>
        /// distribution represents the basic distribution rules of the attribute. The system must adhere to the distribution setting for access control and for dissemination of the attribute.
        /// </summary>
        [JsonProperty("distribution")]
        public Distribution Distribution { get; set; } = Distribution.Inherited;

        /// <summary>
        /// timestamp represents a reference time when the attribute was created or last modified. timestamp is expressed in seconds (decimal) since 1st of January 1970 (Unix timestamp). The time zone MUST be UTC.
        /// </summary>
        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("first_seen")]
        public DateTime? FirstSeen { get; set; }

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("last_seen")]
        public DateTime? LastSeen { get; set; }

        /// <summary>
        /// comment is a contextual comment field.
        /// </summary>
        [JsonProperty("comment")]
        public string Comment { get; set; }

        /// <summary>
        /// sharing_group_id represents a human-readable identifier referencing a Sharing Group object that defines the distribution of the attribute, if distribution level "4" is set. If a distribution level other than "4" is chosen the sharing_group_id MUST be set to "0".
        /// </summary>
        [JsonProperty("sharing_group_id")]
        public string SharingGroupId { get; set; }

        /// <summary>
        /// uuid represents the Universally Unique IDentifier (UUID) [@!RFC4122] of the attribute.
        /// </summary>
        [JsonProperty("uuid")]
        public Guid? UUID { get; set; }
        /// <summary>
        /// uuid represents the Universally Unique IDentifier (UUID) [@!RFC4122] of the attribute.
        /// </summary>
        [JsonProperty("template_uuid")]
        public Guid? TemplateUUID { get; set; }

        [JsonProperty("deleted")]
        public bool Deleted { get; set; } = false;


        [JsonProperty("Attribute")]
        public List<Attribute> Attributes { get; set; } = new List<Attribute>();

    }
}
