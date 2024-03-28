using static FunctionalCSharp.MyYumba.Y;

namespace FunctionalCSharp.MyYumba;

public static class YInt
{
    public static Optiono<int> YParse(string s)
        => int.TryParse(s, out int result)
            ? Somo(result) : Nono;

    public static bool YIsOdd(int i) => i % 2 == 1;

    public static bool YIsEven(int i) => i % 2 == 0;
}