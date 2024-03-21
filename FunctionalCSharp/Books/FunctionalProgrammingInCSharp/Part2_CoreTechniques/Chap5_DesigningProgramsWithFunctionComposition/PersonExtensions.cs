namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition;

public static class PersonExtensions 
{
    public static string AbbreviateName(this Person person) => Abbreviate(person.FirstName)+Abbreviate(person.LastName);
    private static string Abbreviate(string s) => s[..2].ToLower();
}

public static class StringExtensions 
{
    public static string AppendDomain(this string localPart) => $"{localPart}@manning.com";
}