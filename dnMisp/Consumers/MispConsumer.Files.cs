using dnMisp.Enums;
using dnMisp.Misc;
using dnMisp.Objects;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace dnMisp
{
    public partial class MispConsumer
    {

        public Attribute CreateHashes(
            string eid,
            HashType hashType,
            string hash,
            string category = "Artifacts dropped",
            string filename = "",
            string comment = "")
        {
            string attType = hashType.ToString();
            string attValue = hash;

            if (!string.IsNullOrWhiteSpace(filename))
            {
                attType = $"filename|{hashType.ToString()}";
                attValue = $"{filename}|{hash}";
            }

            Attribute newAtt = new Attribute(attType, category, attValue);
            newAtt.Comment = comment;

            return newAtt;
        }

        public Attribute CreateDetectionLink(
            string eid,
            string link,
            string category = "Antivirus detection",
            bool toIds = false,
            string comment = "",
            Distribution distribution = Distribution.Inherited)
        {
            return CreateNamedAttribute(eid, "link", link, category, toIds, comment, distribution);
        }

        public Attribute CreateDetectionName(
            string eid,
            string name,
            string category = "Antivirus detection",
            bool toIds = false,
            string comment = "",
            Distribution distribution = Distribution.Inherited)
        {
            return CreateNamedAttribute(eid, "text", name, category, toIds, comment, distribution);
        }

        public Attribute CreateAttachment(
            string eid,
            Stream attachment,
            string filename,
            string category = "Artifacts dropped",
            bool toIds = false,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            Stream b64stream = Helper.ConvertToBase64(attachment);
            StreamReader b64reader = new StreamReader(b64stream);
            string b64string = b64reader.ReadToEnd();

            return CreateNamedAttribute(eid, "attachment", filename, category, toIds, comment, distribution, b64string, attachToObject: attachToObject);
        }

        public Attribute CreateRegKey(
            string eid,
            string regKey,
            string regValue,
            string category = "Artifacts dropped",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            string typeValue;
            string valValue;

            if (string.IsNullOrWhiteSpace(regValue))
            {
                typeValue = "regkey";
                valValue = regKey;
            }
            else
            {
                typeValue = "regkey|value";
                valValue = $"{regKey}|{regValue}";
            }

            return CreateNamedAttribute(eid, typeValue, valValue, category, toIds, comment, distribution, attachToObject: attachToObject);
        }

        public Attribute CreatePattern(
            string eid,
            string pattern,
            PatternType patternType = PatternType.InFile,
            string category = "Artifacts dropped",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            string pattType = patternType == PatternType.InFile ?
                "pattern-in-file" : "pattern-in-memory";

            return CreateNamedAttribute(eid, pattType, pattern, category, toIds, comment, distribution, attachToObject: attachToObject);
        }

        public Attribute CreatePipe(
            string eid,
            string namedPipe,
            string category = "Artifacts dropped",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "named pipe", namedPipe, category, toIds, comment, distribution, attachToObject: attachToObject);
        }

        public Attribute CreateMutex(
            string eid,
            string mutex,
            string category = "Artifacts dropped",
            bool toIds = true,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "mutex", mutex, category, toIds, comment, distribution, attachToObject: attachToObject);
        }

        public Attribute CreateYara(
            string eid,
            string yara,
            string category = "Payload delivery",
            bool toIds = false,
            string comment = "",
            Distribution distribution = Distribution.Inherited,
            MispObject attachToObject = null)
        {
            return CreateNamedAttribute(eid, "yara", yara, category, toIds, comment, distribution, attachToObject: attachToObject);
        }
    }
}
