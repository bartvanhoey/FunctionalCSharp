namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.MyOption;

public static class MyOptionUseCases
{
    public static string MyOptionGreet(MyOption<string> greetee)
    {
        return greetee switch
        {
            MyNone<string> => "Sorry, who?",
            MySome<string>(var name) => $"Hello, {name}",
            _ => throw new ArgumentOutOfRangeException(nameof(greetee), greetee, null)
        };
    }
    
    public static string MyOptionGreetMatch(MyOption<string> greetee) 
        => greetee.MyMatch(() => "Sorry, Who?", (name) => $"Hello, {name}");
}