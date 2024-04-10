using static FunctionalCSharp.MyYumba.Y;
using Unit = System.ValueTuple;

namespace FunctionalCSharp.MyYumba;

public static class YActionExtensions
{
    public static Func<Unit> YToFunc(this Action action) =>
        () => { action(); return default; };

    public static Func<T, Unit> YToFunc<T>(this Action<T> action)
        => t => { action(t); return default; };

    public static Func<T1, T2, Unit> YToFunc<T1, T2>(this Action<T1, T2> action)
        => (T1 t1, T2 t2) => { action(t1, t2); return default; };

    public static Func<Task<Unit>> YToFunc(this Func<Task> f)
        => async () => { await f(); return Unit(); };

    public static Func<T, Task<Unit>> YToFunc<T>(this Func<T, Task> f)
        => async (t) => { await f(t); return Unit(); };

    public static Func<T1, T2, Task<Unit>> YToFunc<T1, T2>(this Func<T1, T2, Task> f)
        => async (t1, t2) => { await f(t1, t2); return Unit(); };
}