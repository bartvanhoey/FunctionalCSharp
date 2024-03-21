namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.
    MyOption;

public static class MyOptionExtensions
{
    public static R MyMatch<T, R>(this MyOption<T> option, Func<R> none, Func<T, R> some) =>
        option switch
        {
            MyNone<T> => none(),
            MySome<T>(var t) => some(t),
            _ => throw new ArgumentOutOfRangeException(nameof(option), option, null)
        };
}
