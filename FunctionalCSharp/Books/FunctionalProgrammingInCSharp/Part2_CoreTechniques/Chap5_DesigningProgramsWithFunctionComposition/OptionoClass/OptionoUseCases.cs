

using FunctionalCSharp.MyYumba;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.OptionoClass;

public static class OptionoUseCases
{
    // MAP Option
    // (Option<T>, (T -> R)) -> Option<R>
    
    
    // MAP IEnumerable
    // (IEnumerable<T>, (T -> R)) -> IEnumerable<R>
    
    public static string OptionoGreet(Optiono<string> greetee) =>
        greetee.YMatch(
            () => "Sorry, Who?",
            name => $"Hello, {name}"
        );

    // public static string OptionoGreetMatch(Optiono<string> greetee) 
    //     => greetee.MyMatch(() => "Sorry, Who?", (name) => $"Hello, {name}");
}