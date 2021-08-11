using dnMisp.Misc;
using Newtonsoft.Json;
using System.Drawing;

namespace dnMisp.Objects
{
    /// <summary>
    /// A Tag is a simple method to classify an event with a simple tag name.
    /// </summary>
    [JsonObject]
    public class Tag 
        : JsonMispObject
    {

        public Tag() { }

        public Tag(string name) : this()
        {
            Name = name;
        }

        public Tag(string name, Color color, bool isExportable) 
            : this(name, ColorTranslator.ToHtml(color), isExportable)
        {
        }

        public Tag(string name, string color, bool isExportable) : this(name)
        {
            Color = color;
            Exportable = isExportable;
        }

        /// <summary>
        /// The tag name can be freely chosen. The tag name can be also chosen from a fixed machine-tag vocabulary called MISP taxonomies.
        /// </summary>
        [JsonProperty("name"), JsonRequired]
        public string Name { get; set; }

        /// <summary>
        /// id is a human-readable identifier that references the tag on the local instance. 
        /// </summary>
        [JsonProperty("id")]
        public string Id { get; set; }

        /// <summary>
        /// colour represents an RGB value of the tag.
        /// </summary>
        [JsonProperty("colour")]
        public string Color { get; set; }

        /// <summary>
        /// exportable represents a setting if the tag is kept local or exportable to other MISP instances.
        /// </summary>
        [JsonProperty("exportable")]
        public bool? Exportable { get; set; }

        [JsonProperty("org_id")]
        public string OrgID { get; set; }

        [JsonProperty("user_id")]
        public string UserID { get; set; }

        [JsonProperty("hide_tag")]
        public bool? Hidden { get; set; }

        [JsonProperty("numerical_value")]
        public string NumericalValue { get; set; }

        [JsonProperty("is_galaxy")]
        public bool? IsGalaxy { get; set; }

        [JsonProperty("is_custom_galaxy")]
        public bool? IsCustomGalaxy { get; set; }

        [JsonProperty("inherited")]
        public int Inherited { get; set; }

        [JsonProperty("count")]
        public uint? EventCount { get; set; }

        [JsonProperty("attribute_count")]
        public uint? AttributeCount { get; set; }

    }
}
