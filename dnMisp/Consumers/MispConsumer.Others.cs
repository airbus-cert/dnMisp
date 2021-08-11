using dnMisp.Enums;
using dnMisp.Objects;
using System.Threading.Tasks;

namespace dnMisp
{
    public partial class MispConsumer
    {
        #region Other attributes

        public Attribute CreateOtherComment(
            string eid,
            string value,
            string category = "Other",
            bool toIds = false,
            string comment = "",
            Distribution distribution = Distribution.Inherited)
        {
            return CreateNamedAttribute(eid, "comment", value, category, toIds, comment, distribution);
        }
        public Attribute CreateOtherCounter(
            string eid,
            string value,
            string category = "Other",
            bool toIds = false,
            string comment = "",
            Distribution distribution = Distribution.Inherited)
        {
            return CreateNamedAttribute(eid, "counter", value, category, toIds, comment, distribution);
        }
        public Attribute CreateOtherText(
            string eid,
            string value,
            string category = "Other",
            bool toIds = false,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "text", value, category, toIds, comment, distribution, attachToObject: attachToObject);
        }
        #endregion

    }
}
