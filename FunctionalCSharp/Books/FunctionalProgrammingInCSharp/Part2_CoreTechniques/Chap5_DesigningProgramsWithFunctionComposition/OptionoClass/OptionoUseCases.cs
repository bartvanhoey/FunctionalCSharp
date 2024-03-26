namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.OptionoClass;

public static class OptionoUseCases
{
    public static string OptionoGreet(Optiono<string> greetee) =>
        greetee.Match(
            () => "Sorry, Who?",
            name => $"Hello, {name}"
        );

    // public static string OptionoGreetMatch(Optiono<string> greetee) 
    //     => greetee.MyMatch(() => "Sorry, Who?", (name) => $"Hello, {name}");
}