using dnMisp.Enums;
using Newtonsoft.Json;
using System;

namespace dnMisp.Objects
{
    public class GalaxyCluster
        : JsonMispObject
    {
        [JsonProperty("id")] public string Id { get; set; }
        [JsonProperty("uuid")] public Guid UUID { get; set; }
        [JsonProperty("collection_uuid")] public Guid CollectionUUID { get; set; }
        [JsonProperty("type")] public string Type { get; set; }
        [JsonProperty("value")] public string Value { get; set; }
        [JsonProperty("tag_name")] public string TagName { get; set; }
        [JsonProperty("description")] public string Description { get; set; }
        [JsonProperty("galaxy_id")] public string GalaxyId { get; set; }
        [JsonProperty("source")] public string Source { get; set; }
        [JsonProperty("authors")] public string[] Authors { get; set; }
        [JsonProperty("version")] public string Version { get; set; }
        [JsonProperty("distribution")] public Distribution Distribution { get; set; }
        [JsonProperty("sharing_group_id")] public string SharingGroupId { get; set; }
        [JsonProperty("org_id")] public string OrganizationID { get; set; }
        [JsonProperty("orgc_id")] public string OrganizationCID { get; set; }
        [JsonProperty("default")] public bool Default { get; set; }
        [JsonProperty("locked")] public bool Locked { get; set; }
        [JsonProperty("extends_version")] public Guid ExtendsUUID { get; set; }
        [JsonProperty("published")] public bool Published { get; set; }
        [JsonProperty("deleted")] public bool Deleted { get; set; }
        [JsonProperty("GalaxyElement")] public GalaxyElement[] GalaxyElements { get; set; }
        [JsonProperty("Galaxy")] public Galaxy Galaxy { get; set; }
        [JsonProperty("GalaxyClusterRelation")] public GalaxyElement[] GalaxyClusterRelations { get; set; }
        [JsonProperty("Org")] public Org Org { get; set; }
        [JsonProperty("Orgc")] public Org OrgC { get; set; }
        [JsonProperty("tag_count")] public string TagCount { get; set; }
        [JsonProperty("tag_id")] public string TagId { get; set; }
        [JsonProperty("meta")] public object[] Meta { get; set; }

    }
}
