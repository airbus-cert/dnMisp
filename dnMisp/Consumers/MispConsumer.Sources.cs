using dnMisp.Enums;
using dnMisp.Objects;

namespace dnMisp
{
    public partial class MispConsumer
    {
        #region Source attributes
        public Attribute CreateThreatActor(
            string eid,
            string value,
            string category = "Attribution",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited)
        {
            return CreateNamedAttribute(eid, "threat-actor", value, category, toIds, comment, distribution);
        }

        #endregion
    }
}
