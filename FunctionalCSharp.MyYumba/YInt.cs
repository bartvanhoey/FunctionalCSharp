using static FunctionalCSharp.MyYumba.Y;

namespace FunctionalCSharp.MyYumba;

public static class YInt
{
    public static YOption<int> YIntParse(string? s)
        => int.TryParse(s, out var result)
            ? YSome(result) : YNone;

    public static bool YIsOdd(int i) => i % 2 == 1;

    // public static bool YIsEven(int i) => i % 2 == 0;
    
    public static readonly Func<int, bool> YIsEven = i => i % 2 == 0;
    
}