using dnMisp.Enums;
using dnMisp.Objects;
using System.Threading.Tasks;

namespace dnMisp
{
    public partial class MispConsumer
    {
        #region Internal Reference attributes
        public Attribute CreateInternalLink(
            string eid,
            string value,
            string category = "Internal reference",
            bool toIds = false,
            string comment = "",
            Distribution distribution = Distribution.Inherited)
        {
            return CreateNamedAttribute(eid, "link", value, category, toIds, comment, distribution);
        }

        public Attribute CreateInternalComment(
            string eid,
            string value,
            string category = "Internal reference",
            bool toIds = false,
            string comment = "",
            Distribution distribution = Distribution.Inherited)
        {
            return CreateNamedAttribute(eid, "comment", value, category, toIds, comment, distribution);
        }

        public Attribute CreateInternalText(
            string eid,
            string value,
            string category = "Internal reference",
            bool toIds = false,
            string comment = "",
            Distribution distribution = Distribution.Inherited)
        {
            return CreateNamedAttribute(eid, "text", value, category, toIds, comment, distribution);
        }

        public Attribute CreateInternalOther(
            string eid,
            string value,
            string category = "Internal reference",
            bool toIds = false,
            string comment = "",
            Distribution distribution = Distribution.Inherited)
        {
            return CreateNamedAttribute(eid, "other", value, category, toIds, comment, distribution);
        }
        #endregion

    }
}
