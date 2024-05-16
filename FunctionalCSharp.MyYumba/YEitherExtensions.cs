using static FunctionalCSharp.MyYumba.Y;
using Unit = System.ValueTuple;


namespace FunctionalCSharp.MyYumba;

public static partial class YEitherExtensions
{
    public static string RenderResult(this YEither<string, double> value)
        => value.YMatch(l => $"Invalid value: {l}", r => $"The result is: {r}");

    public static YEither<L, Rr> YMap<L, R, Rr>(this YEither<L, R> either, Func<R, Rr> f) 
        => either.YMatch<YEither<L, Rr>>(l =>YLeft(l), r => YRight(f(r)));

    public static YEither<L, Unit> YForEach<L, R>(this YEither<L, R> either, Action<R> action)
        => either.YMap(action.YToFunc());
    
    public static YEither<L, Rr> YBind<L, R, Rr>(this YEither<L, R> either, Func<R, YEither<L, Rr>> func)
        => either.YMatch(l=> YLeft(l), func);


}