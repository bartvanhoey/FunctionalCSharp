using static System.Environment;
using static System.Text.Encoding;

namespace FunctionalCSharp.Functional.MethodChaining
{
    public static class StreamFactory
    {
        public static Stream GetStream()
        {
            var doctors = string.Join( NewLine, "Hartnell", "Troughton", "Pertwee", "T. Baker", "Davison", "C. Baker", "McCoy",
                "McGann", "Hurt", "Eccleston", "Tennant", "Smith", "Capaldi");

            var buffer = UTF8.GetBytes(doctors);

            var stream = new MemoryStream();
            stream.Write(buffer, 0, buffer.Length);
            stream.Position = 0L;

            return stream;
        }
    }
}