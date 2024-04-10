

using FunctionalCSharp.MyYumba;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.yOptionClass;

public static class yOptionUseCases
{
    // MAP Option
    // (Option<T>, (T -> R)) -> Option<R>
    
    
    // MAP IEnumerable
    // (IEnumerable<T>, (T -> R)) -> IEnumerable<R>
    
    public static string yOptionGreet(YOption<string> greetee) =>
        greetee.YMatch(
            () => "Sorry, Who?",
            name => $"Hello, {name}"
        );

    // public static string yOptionGreetMatch(yOption<string> greetee) 
    //     => greetee.MyMatch(() => "Sorry, Who?", (name) => $"Hello, {name}");
}