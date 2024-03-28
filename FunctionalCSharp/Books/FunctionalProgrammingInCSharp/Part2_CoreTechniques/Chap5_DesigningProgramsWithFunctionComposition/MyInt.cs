
using FunctionalCSharp.MyYumba;
using static System.Int32;
using static FunctionalCSharp.MyYumba.Y;


namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition;

public static class MyInt
{
    public static Optiono<int> Parse(string text) 
        => TryParse(text, out var result) ? Somo(result) : Nono;
}