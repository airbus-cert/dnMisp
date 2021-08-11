using Newtonsoft.Json.Converters;

namespace dnMisp.Misc
{
    public class RestSearchDateTimeConverter : IsoDateTimeConverter
    {
        public RestSearchDateTimeConverter()
        {
            DateTimeFormat = "yyyy-MM-dd";
        }
    }
}
