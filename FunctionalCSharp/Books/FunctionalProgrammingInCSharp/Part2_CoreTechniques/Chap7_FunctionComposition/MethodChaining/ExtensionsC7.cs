namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.MethodChaining;

public static class ExtensionsC7
{
    public static string AbbreviateName(this PersonC7 personC7) 
        => Abbreviate(personC7.FirstName) + Abbreviate(personC7.LastName);
        
    private static string Abbreviate(string text) 
        => text[..Math.Min(2, text.Length)].ToLower();
        
    public static string AddDomain(this string localPart) 
        => $"{localPart}@manning.com";
        
        
}