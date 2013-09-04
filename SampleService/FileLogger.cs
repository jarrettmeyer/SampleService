using System.IO;
using System.Text;

namespace SampleService
{
    public class FileLogger : ILogger
    {
        private const string FILE_NAME = "log.txt";

        public void Write(string message)
        {
            using (var fileStream = new FileStream(FILE_NAME, FileMode.Append))
            {
                byte[] bytes = Encoding.UTF8.GetBytes(message + "\n\n");
                int length = bytes.Length;
                fileStream.Write(bytes, 0, length);
            }
        }
    }
}
