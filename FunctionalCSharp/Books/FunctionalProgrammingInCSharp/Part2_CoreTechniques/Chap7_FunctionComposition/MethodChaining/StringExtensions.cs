namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.MethodChaining;

public static class StringExtensions
{
    private static string AppendDomain(this string localPart) 
        => $"{localPart}@manning.com";
}