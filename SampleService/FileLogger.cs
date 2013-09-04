using System.IO;
using SampleService.Properties;

namespace SampleService
{
    public class FileLogger : ILogger
    {
        private readonly static string fileName = Settings.Default.LogFileName;

        public void Write(string message)
        {
            using (var fileStream = new FileStream(fileName, FileMode.Append))
            {
                message = message.Append("\n\n");
                byte[] bytes = message.ToUTF8ByteArray();
                int length = bytes.Length;
                fileStream.Write(bytes, 0, length);
            }
        }
    }
}
