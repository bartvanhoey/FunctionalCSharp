namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap5_DesigningProgramsWithFunctionComposition;

public class Chap05
{
    private Func<Person, string> emailFor = p => AppendDomain(AbbreviateName(p));

    private static string AbbreviateName(Person p) => Abbreviate(p.FirstName) + Abbreviate(p.LastName);
    private static string AppendDomain(string localPart) => $"{localPart}@manning.com";
    private static string Abbreviate(string s) => s[..2].ToLower();
    
    public void MethodChaining()
    {
        var joe = new Person("Joe", "Blogs");
        var JoeEmail = emailFor(joe);

        
        var joeEmailFunctional = joe.AbbreviateName().AppendDomain();
    }

}