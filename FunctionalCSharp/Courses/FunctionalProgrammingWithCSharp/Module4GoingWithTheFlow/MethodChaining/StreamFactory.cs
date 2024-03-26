using static System.Environment;
using static System.Text.Encoding;

namespace FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module4GoingWithTheFlow.MethodChaining;

public static class StreamFactory
{
    public static Stream GetDoctors()
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