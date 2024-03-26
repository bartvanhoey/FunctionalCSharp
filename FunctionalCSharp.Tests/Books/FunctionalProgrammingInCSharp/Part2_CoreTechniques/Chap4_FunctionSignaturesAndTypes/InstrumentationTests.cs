using FluentAssertions;
using static System.IO.File;
using static System.IO.Path;
using static System.Reflection.Assembly;
using static System.Text.Encoding;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap4_FunctionSignaturesAndTypes.
    Instrumentation;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.
    Chap4_FunctionSignaturesAndTypes;

public class InstrumentationTests
{
    [Fact]
    public void MethodTime_When_Executing_FileReadAllText_ShouldReturn_NotNull()
    {
        var filePath = GetFilePath("file.txt");
        var result = WriteTimeTakenToConsole("Reading from file.txt", () => ReadAllText(filePath));
        result.Should().NotBeNull();
    }

    [Fact]
    public void MethodTime_When_Executing_FileAppendText_ShouldReturn_NotNull()
    {
        var filePath = GetFilePath("file.txt");
        WriteTimeTakenToConsole("Writing to file.txt", () => AppendAllText(filePath, "Hello World", UTF8));
    }

    private static string GetFilePath(string fileName)
        => Combine(GetDirectoryName(GetExecutingAssembly().Location) ?? throw new InvalidOperationException(),
            fileName);
}