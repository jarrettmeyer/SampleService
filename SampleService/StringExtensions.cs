using System.Text;

namespace SampleService
{
    public static class StringExtensions
    {
        public static string Append(this string str, string appendWith)
        {
            if (str == null)
                str = "";
            return string.Concat(str, appendWith);
        }

        public static byte[] ToUTF8ByteArray(this string str)
        {
            if (str == null)
                return new byte[] { };
            return Encoding.UTF8.GetBytes(str);
        }
    }
}
