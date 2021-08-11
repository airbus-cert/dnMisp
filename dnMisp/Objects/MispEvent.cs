using System;
using dnMisp.Enums;
using dnMisp.Misc;
using Newtonsoft.Json;

namespace dnMisp.Objects
{
    public class MispEvent
        : JsonMispObject
    {
        public MispEvent()
        {
            Info = "";
        }
        /// <summary>
        /// uuid represents the Universally Unique IDentifier (UUID) [@!RFC4122] of the event
        /// </summary>
        [JsonProperty("uuid")]
        public Guid? UUID { get; set; }

        /// <summary>
        /// id represents the human-readable identifier associated to the event for a specific MISP instance.
        /// </summary>
        [JsonProperty("id")]
        public int Id { get; set; }

        /// <summary>
        /// published represents the event publication state. If the event was published, the published value MUST be true. In any other publication state, the published value MUST be false.
        /// </summary>
        [JsonProperty("published")]
        public bool? Published { get; set; }


        private string _info = null;
        /// <summary>
        /// info represents the information field of the event. info a free-text value to provide a human-readable summary of the event. info SHOULD NOT be bigger than 256 characters and SHOULD NOT include new-lines.
        /// </summary>
        [JsonProperty("info"), JsonRequired]
        public string Info
        {
            get { return _info; }
            set
            {
                _info = value.Replace(Environment.NewLine, " ");
                if (_info.Length > 256)
                    _info = _info.Substring(0, 256);
            }
        }

        /// <summary>
        /// threat_level_id represents the threat level.
        /// </summary>
        [JsonProperty("threat_level_id")]
        public ThreatLevel ThreatLevelId { get; set; }

        /// <summary>
        /// analysis represents the analysis level.
        /// </summary>
        [JsonProperty("analysis")]
        internal string _analysisStr
        {
            get { return ((int)AnalysisLevel).ToString(); }
            set
            {
                int v;
                if (int.TryParse(value, out v))
                {
                    AnalysisLevel = (AnalysisLevel)v;
                }
            }
        }

        [JsonIgnore]
        public AnalysisLevel AnalysisLevel { get; set; }


        /// <summary>
        /// date represents a reference date to the event in ISO 8601 format (date only: YYYY-MM-DD). This date corresponds to the date the event occured, which may be in the past.
        /// </summary>
        [JsonProperty("date")]
        internal string _date { get; set; }

        /// <summary>
        /// date represents a reference date to the event. This date corresponds to the date the event occured, which may be in the past.
        /// </summary>
        [JsonIgnore] public DateTime Date { get { return DateTime.ParseExact(_date, "yyyy-MM-dd", null); } set { _date = value.ToString("yyyy-MM-dd"); } }

        [JsonProperty("timestamp")]
        internal string _ts { get; set; }

        /// <summary>
        /// timestamp represents a reference time when the event, or one of the attributes within the event was created, or last updated/edited on the instance.
        /// </summary>
        [JsonIgnore]
        public DateTime Timestamp
        {
            get { return Helper.TimeFromUnixTimestamp(int.Parse(_ts)); }
            set { _ts = Helper.UnixTimestampFromDateTime(value).ToString(); }
        }

        /// <summary>
        /// publish_timestamp represents a reference time when the event was published on the instance. published_timestamp is expressed in seconds (decimal) since 1st of January 1970 (Unix timestamp). At each publication of an event, publish_timestamp MUST be updated. The time zone MUST be UTC.
        /// </summary>
        [JsonProperty("publish_timestamp")]
        public string PublishTimestamp { get; set; }

        [JsonProperty("sighting_timestamp")]
        public string SightingTimestamp { get; set; }

        /// <summary>
        /// org_id represents a human-readable identifier referencing an Org object of the organization which generated the event.
        /// </summary>
        [JsonProperty("org_id")]
        public string OrgId { get { return Org != null ? Org.Id : null; } set { } }

        /// <summary>
        /// orgc_id represents a human-readable identifier referencing an Orgc object of the organization which created the event.
        /// </summary>
        [JsonProperty("orgc_id")]
        public string OrgCId { get { return OrgC != null ? OrgC.Id : null; } set { } }

        /// <summary>
        /// attribute_count represents the number of attributes in the event. attribute_count is expressed in decimal.
        /// </summary>
        [JsonProperty("attribute_count")]
        public string AttributeCount { get { return Attribute != null ? Attribute.Length.ToString() : "0"; } set { } }

        /// <summary>
        /// distribution represents the basic distribution rules of the event. The system must adhere to the distribution setting for access control and for dissemination of the event.
        /// </summary>
        [JsonProperty("distribution")]
        public string Distribution { get; set; }

        /// <summary>
        /// sharing_group_id represents a human-readable identifier referencing a Sharing Group object that defines the distribution of the event, if distribution level "4" is set. If a distribution level other than "4" is chosen the sharing_group_id MUST be set to "0".
        /// </summary>
        [JsonProperty("sharing_group_id")]
        public string SharingGroupId { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Org")]
        public Org Org { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Orgc")]
        public Org OrgC { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Attribute")]
        public Attribute[] Attribute { get; set; }

        /// <summary>
        /// ??
        /// </summary>
        [JsonProperty("ShadowAttribute")]
        public ShadowAttribute[] ShadowAttribute { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [JsonProperty("Tag")]
        public Tag[] Tag { get; set; }

        /// <summary>
        /// ??
        /// </summary>
        [JsonProperty("locked")]
        public bool? Locked { get; set; }

        /// <summary>
        /// ??
        /// </summary>
        [JsonProperty("disable_correlation")]
        public bool? DisableCorrelation { get; set; }

        /// <summary>
        /// ??
        /// </summary>
        [JsonProperty("RelatedEvent")]
        public RelatedEvent[] RelatedEvent { get; set; }

        /// <summary>
        /// ??
        /// </summary>
        [JsonProperty("Galaxy")]
        public Galaxy[] Galaxy { get; set; }

        [JsonProperty("Object")]
        public MispObject[] Objects { get; set; }


        public string GetId()
        {
            if (UUID.HasValue)
                return UUID.ToString();
            else
                return Id.ToString();
        }
    }
}
