using FunctionalCSharp.MyYumba;
using static System.Console;
using static FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming.Chap6Age;
using static FunctionalCSharp.MyYumba.YInt;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap6_PatternsInFunctionalProgramming;

public static class Chap6AgeReader
{
    public static void StartProgram() 
        => WriteLine($"Only {ReadAge()}! That's young!");

    private static Chap6Age ReadAge() // use recursion to call itself again
        => ParseAge(AskUserAge("Please enter your age:")).YMatch(ReadAge, x => x);

    private static string? AskUserAge(string message)
    {
        WriteLine(message);
        return ReadLine();
    }

    private static YOption<Chap6Age> ParseAge(string? age) 
        => YIntParse(age).YBind(CreateAge);
    
    
    
}