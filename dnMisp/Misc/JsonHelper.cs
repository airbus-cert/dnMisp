using Newtonsoft.Json;
using System.Net.Http.Formatting;

namespace dnMisp.Misc
{
    public static class JsonHelper
    {
        static JsonHelper()
        {
            settings = new JsonSerializerSettings();
            settings.DateFormatString = "YYYY-MM-DD";
            settings.NullValueHandling = NullValueHandling.Ignore;
            settings.DefaultValueHandling = DefaultValueHandling.Ignore;
            settings.Formatting = Formatting.None;
            settings.StringEscapeHandling = StringEscapeHandling.Default;

            Formatter = new JsonMediaTypeFormatter();
            Formatter.SerializerSettings = settings;
        }
        public static JsonMediaTypeFormatter Formatter { get; set; }
        private static JsonSerializerSettings settings;

        internal static JsonSerializerSettings Settings { get { return settings; } }


        public static string JSerialize(object obj)
        {
            return JsonConvert.SerializeObject(obj,
                               Formatting.None,
                               JsonHelper.Settings);
        }

        public static string JSerialize<T>(T obj)
        {
            return JsonConvert.SerializeObject(obj,
                               Formatting.None,
                               JsonHelper.Settings);
        }

        public static T JDeserialize<T>(string jsonObject)
        {
            return JsonConvert.DeserializeObject<T>(jsonObject,
                               JsonHelper.Settings);
        }
    }
}
