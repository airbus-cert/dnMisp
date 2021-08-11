using dnMisp.Misc;
using Newtonsoft.Json;

namespace dnMisp.Objects
{
    [JsonObject]
    public abstract class JsonBaseObject
    {
        public override string ToString()
        {
            return ToJson();
        }

        internal string ToJson()
        {
            return JsonHelper.JSerialize(this);
        }
    }
}