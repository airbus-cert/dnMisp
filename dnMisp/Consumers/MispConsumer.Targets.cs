using dnMisp.Enums;
using dnMisp.Objects;
using System.Threading.Tasks;

namespace dnMisp
{
    public partial class MispConsumer
    {

        #region Target attributes
        public Attribute CreateTargetEmail(
            string eid,
            string value,
            string category = "Targeting data",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited)
        {
            return CreateNamedAttribute(eid, "target-email", value, category, toIds, comment, distribution);
        }

        public Attribute CreateTargetUser(
            string eid,
            string value,
            string category = "Targeting data",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited)
        {
            return CreateNamedAttribute(eid, "target-user", value, category, toIds, comment, distribution);
        }

        public Attribute CreateTargetMachine(
            string eid,
            string value,
            string category = "Targeting data",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited)
        {
            return CreateNamedAttribute(eid, "target-machine", value, category, toIds, comment, distribution);
        }

        public Attribute CreateTargetOrganization(
            string eid,
            string value,
            string category = "Targeting data",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited)
        {
            return CreateNamedAttribute(eid, "target-org", value, category, toIds, comment, distribution);
        }

        public Attribute CreateTargetLocation(
            string eid,
            string value,
            string category = "Targeting data",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited)
        {
            return CreateNamedAttribute(eid, "target-location", value, category, toIds, comment, distribution);
        }

        public Attribute CreateTargetExternal(
            string eid,
            string value,
            string category = "Targeting data",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited)
        {
            return CreateNamedAttribute(eid, "target-external", value, category, toIds, comment, distribution);
        }
        #endregion

    }
}
