using dnMisp.Enums;
using dnMisp.Objects;
using System.Threading.Tasks;

namespace dnMisp
{
    public partial class MispConsumer
    {
        #region Email attributes

        public Attribute CreateEmailSrc(
            string eid,
            string value,
            string category = "Payload delivery",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "email-src", value, category, toIds, comment, distribution, attachToObject: attachToObject);
        }

        public Attribute CreateEmailDst(
            string eid,
            string value,
            string category = "Payload delivery",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "email-dst", value, category, toIds, comment, distribution, attachToObject: attachToObject);
        }

        public Attribute CreateEmailSubject(
            string eid,
            string value,
            string category = "Payload delivery",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "email-subject", value, category, toIds, comment, distribution, attachToObject: attachToObject);
        }

        public Attribute CreateEmailAttachment(
            string eid,
            string value,
            string category = "Payload delivery",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "email-attachment", value, category, toIds, comment, distribution, attachToObject: attachToObject);
        }

        public Attribute CreateEmailHeader(
            string eid,
            string value,
            string category = "Payload delivery",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "email-header", value, category, toIds, comment, distribution, attachToObject: attachToObject);
        }
        #endregion

    }
}
