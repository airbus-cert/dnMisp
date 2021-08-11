using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace dnMisp.Misc
{
    public static class Helper
    {
        public static DateTime TimeFromUnixTimestamp(int unixTimestamp)
        {
            DateTime unixYear0 = new DateTime(1970, 1, 1);
            long unixTimeStampInTicks = unixTimestamp * TimeSpan.TicksPerSecond;
            DateTime dtUnix = new DateTime(unixYear0.Ticks + unixTimeStampInTicks);
            return dtUnix;
        }

        public static long UnixTimestampFromDateTime(DateTime date)
        {
            long unixTimestamp = date.Ticks - new DateTime(1970, 1, 1).Ticks;
            unixTimestamp /= TimeSpan.TicksPerSecond;
            return unixTimestamp;
        }

        public static string GetHash<T>(byte[] input)
            where T : HashAlgorithm
        {
            HashAlgorithm hashAlgorithm = HashAlgorithm.Create(typeof(T).Name);
            // Convert the input string to a byte array and compute the hash.
            byte[] data = hashAlgorithm.ComputeHash(input);

            hashAlgorithm.Dispose();

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            var sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
        public static Stream ConvertToBase64(Stream stream)
        {
            BinaryReader br = new BinaryReader(stream);
            stream.Position = 0;
            return new MemoryStream(Encoding.UTF8.GetBytes(System.Convert.ToBase64String(br.ReadBytes((int)stream.Length))));
        }

        public static string ToBase64(Stream stream)
        {
            BinaryReader br = new BinaryReader(stream);
            stream.Position = 0;
            return System.Convert.ToBase64String(br.ReadBytes((int)stream.Length));
        }


        public static string ConvertToBase64(string plainText)
        {
            var plainTextBytes = System.Text.Encoding.UTF8.GetBytes(plainText);
            return System.Convert.ToBase64String(plainTextBytes);
        }

    }
}
