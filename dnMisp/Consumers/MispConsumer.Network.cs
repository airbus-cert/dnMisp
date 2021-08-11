using dnMisp.Enums;
using dnMisp.Objects;
using System.Threading.Tasks;

namespace dnMisp
{
    public partial class MispConsumer
    {
        #region Network activity
        public Attribute CreateIPDst(
            string eid,
            string value,
            string category = "Network activity",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "ip-dst", value, category, toIds, comment, distribution, attachToObject: attachToObject);
        }

        public Attribute CreateIPSrc(
            string eid,
            string value,
            string category = "Network activity",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "ip-src", value, category, toIds, comment, distribution, attachToObject: attachToObject);
        }

        public Attribute CreateHostname(
            string eid,
            string value,
            string category = "Network activity",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "hostname", value, category, toIds, comment, distribution, attachToObject: attachToObject);
        }

        public Attribute CreateDomain(
            string eid,
            string value,
            string category = "Network activity",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "domain", value, category, toIds, comment, distribution, attachToObject: attachToObject);
        }

        public Attribute CreateDomainIP(
            string eid,
            string domain,
            string ip,
            string category = "Network activity",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "domain|ip", $"{domain}|{ip}", category, toIds, comment, distribution, attachToObject: attachToObject);
        }

        public Attribute CreateUrl(
            string eid,
            string url,
            string category = "Network activity",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "url", url, category, toIds, comment, distribution, attachToObject: attachToObject);
        }

        public Attribute CreateUserAgent(
            string eid,
            string userAgent,
            string category = "Network activity",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "user-agent", userAgent, category, toIds, comment, distribution, attachToObject: attachToObject);
        }

        public Attribute CreateTrafficPattern(
            string eid,
            string pattern,
            string category = "Network activity",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "pattern-in-traffic", pattern, category, toIds, comment, distribution, attachToObject: attachToObject);
        }

        public Attribute CreateSnort(
            string eid,
            string snort,
            string category = "Network activity",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "snort", snort, category, toIds, comment, distribution, attachToObject: attachToObject);
        }

        public Attribute CreateASN(
            string eid,
            string asn,
            string category = "Network activity",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "AS", asn, category, toIds, comment, distribution, attachToObject: attachToObject);
        }

        public Attribute CreateNetOther(
            string eid,
            string value,
            string category = "Network activity",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "other", value, category, toIds, comment, distribution, attachToObject: attachToObject);
        }
        #endregion
    }
}
