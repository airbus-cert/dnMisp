using System.Drawing;

namespace dnMisp.Misc
{
    internal static class ColorTranslator
    {
        public static string ToHtml(Color c)
        {
            string colorString = string.Empty;

            if (c.IsEmpty)
                return colorString;

            colorString = "#" + c.R.ToString("X2", null) +
                                c.G.ToString("X2", null) +
                                c.B.ToString("X2", null);

            return colorString;
        }
    }
}