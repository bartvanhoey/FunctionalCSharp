using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.OptionoClass;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.Newsletter;

public record Subscriber(string Name, string Email);
public record OptSubscriber(Optiono<string> Name, string Email);

public static class NewsLetterService
{
    public static string GreetingFor(Subscriber subscriber) 
        => $"Dear {subscriber.Name.ToUpper()},";

    public static string OptGreetingFor(OptSubscriber subscriber) 
        => subscriber.Name.Match(
            () => "Dear Subscriber,", 
            x => $"Dear {x.ToUpper()},");
}