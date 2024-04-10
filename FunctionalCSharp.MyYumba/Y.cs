using Unit = System.ValueTuple;

namespace FunctionalCSharp.MyYumba;

public static class Y
{
    public static Unit Unit() => default;
    
    public static YOption<T> YSome<T>(T value) => new(value);
    public static YNoneType YNone => default;
}