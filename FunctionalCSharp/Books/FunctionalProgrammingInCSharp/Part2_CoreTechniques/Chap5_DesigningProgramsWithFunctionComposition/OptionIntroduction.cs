using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition;

public static class OptionIntroduction
{
    // Option<T> = None | Some(T)
    // None: indicating the absence of a value => The Option is None
    // Some(T): A Container that wraps a value of T => The Option is Some
    
    public static string Greet(Option<string> greetee) 
        => greetee.Match(() => "Sorry, Who?", s => $"Hello, {s}");
    
    
}