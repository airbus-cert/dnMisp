using dnMisp.Misc;
using Newtonsoft.Json;

namespace dnMisp.Objects
{

    [JsonObject]
    public class ShadowAttribute : Attribute
    {
        /// <summary>
        /// old_id represents a human-readable identifier referencing the Attribute object that the ShadowAttribute belongs to. A ShadowAttribute can this way target an existing Attribute, implying that it is a proposal to modify an existing Attribute, or alternatively it can be a proposal to create a new Attribute for the containing Event.
        /// </summary>
        [JsonProperty("old_id")]
        public string OldId { get; set; }

        /// <summary>
        /// org_id represents a human-readable identifier referencing the proposal creator's Organisation object.
        /// Whilst attributes can only be created by the event creator organisation, shadow attributes can be created by third parties.org_id tracks the creator organisation.
        /// </summary>
        [JsonProperty("org_id")]
        public string OrgId { get; set; }


        /// <summary>
        /// proposal_to_delete is a boolean flag that sets whether the shadow attribute proposes to alter an attribute, or whether it proposes to remove it completely.
        /// Accepting a shadow attribute with this flag set will remove the target attribute.
        /// </summary>
        [JsonProperty("proposal_to_delete")]
        public bool? ProposalToDelete { get; set; }



    }
}
