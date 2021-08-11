using dnMisp.Enums;
using dnMisp.Misc;
using Newtonsoft.Json;
using System;

namespace dnMisp.Objects
{
    [JsonObject]
    public class Attribute 
        : JsonMispObject
    {
        public Attribute()
        {
            Distribution = Distribution.Inherited;
        }

        public Attribute(string type, string value) : this()
        {
            Type = type;
            Value = value;
        }

        public Attribute(string type, string category, string value) 
            : this(type, value)
        {
            Category = category;
        }

        public Attribute(string type, string category, string value, bool toIDS) 
            : this(type, category, value)
        {
            ToIDS = toIDS;
        }

        /// <summary>
        /// uuid represents the Universally Unique IDentifier (UUID) [@!RFC4122] of the attribute.
        /// </summary>
        [JsonProperty("uuid")]
        public Guid? UUID { get; set; }

        /// <summary>
        /// id represents the human-readable identifier associated to the attribute for a specific MISP instance.
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// id represents the human-readable identifier associated to the attribute for a specific MISP instance.
        /// </summary>
        [JsonProperty("event_id")]
        public string EventId { get; set; }

        /// <summary>
        /// id represents the human-readable identifier associated to the attribute for a specific MISP instance.
        /// </summary>
        [JsonProperty("object_id")]
        public string ObjectId { get; set; }

        /// <summary>
        /// type represents the means through which an attribute tries to describe the intent of the attribute creator, using a list of pre-defined attribute types.
        /// </summary>
        [JsonProperty("type"), JsonRequired]
        public string Type { get; set; }


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
        /// distribution represents the basic distribution rules of the attribute. The system must adhere to the distribution setting for access control and for dissemination of the attribute.
        /// </summary>
        [JsonProperty("distribution")]
        public Distribution Distribution { get; set; }

        /// <summary>
        /// timestamp represents a reference time when the attribute was created or last modified. timestamp is expressed in seconds (decimal) since 1st of January 1970 (Unix timestamp). The time zone MUST be UTC.
        /// </summary>

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("timestamp")]
        public DateTime? Timestamp { get; set; }

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
        /// data contains the base64 encoded contents of an attachment or a malware sample. For malware samples, the sample MUST be encrypted using a password protected zip archive, with the password being "infected". 
        /// data is represented by a JSON string in base64 encoding. data MUST be set for attributes of type malware-sample and attachment.
        /// </summary>
        [JsonProperty("data")]
        public string Data { get; set; }

        /// <summary>
        /// value represents the payload of an attribute.
        /// </summary>
        [JsonProperty("value"), JsonRequired]
        public string Value { get; set; }

        /// <summary>
        /// ??
        /// </summary>
        [JsonProperty("disable_correlation")]
        public bool DisableCorrelation { get; set; }

        /// <summary>
        /// Is attribute soft-deleted
        /// </summary>
        [JsonProperty("deleted")]
        public bool Deleted { get; set; }


        [JsonProperty("object_relation")]
        public string ObjectRelation { get; set; } = null;

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("first_seen")]
        public DateTime? FirstSeen { get; set; } = null;

        [JsonConverter(typeof(UnixDateTimeConverter))]
        [JsonProperty("last_seen")]
        public DateTime? LastSeen { get; set; } = null;


        public bool IsMD5()
        {
            return Type.Equals("md5", StringComparison.OrdinalIgnoreCase);
        }

        public bool IsFromTool(string toolName)
        {
            return Comment.ToLower().Contains(toolName.ToLower());
        }

        public bool IsRootAttr()
        {
            return (string.IsNullOrWhiteSpace(ObjectId) || ObjectId == "0");
        }

        public bool IsAttachment()
        {
            return Type.Equals("attachment");
        }

        public bool IsMalwareSample()
        {
            return Type.Equals("malware-sample", StringComparison.OrdinalIgnoreCase) ||
                (ObjectRelation?.Equals("malware-sample", StringComparison.OrdinalIgnoreCase) ?? false);
        }
        public bool IsScript()
        {
            return Type.Equals("script", StringComparison.OrdinalIgnoreCase) || 
                (ObjectRelation?.Equals("script-as-attachment", StringComparison.OrdinalIgnoreCase) ?? false) ||
                (ObjectRelation?.Equals("script", StringComparison.OrdinalIgnoreCase) ?? false);
        }

    }
}
