using static FunctionalCSharp.MyYumba.Y;
using Unit = System.ValueTuple;

namespace FunctionalCSharp.MyYumba;

public static class YOptionExtensions {
    
    // MAP (C<T>, (T -> R)) -> C<R>
    // in FP, a type for which a Map function is defined is a Functor
    // Map should apply a function to the container's inner vale,
    // and should do nothing else (should have no side effects)
    public static YOption<R> YMap<T, R>(this YOption<T> yOption, Func<T, R> func) 
        => yOption.YMatch(() => YNone, x => YSome(func(x)));

    // FOREACH is similar to MAP but takes an Action instead of a Function => used for its side effects
    public static YOption<Unit> YForEach<T>(this YOption<T> yOption, Action<T> action)
        => yOption.YMap(action.YToFunc());


    // BIND takes an Option-returning function and applies the function to the inner value of the option
    // in FP, a type for which a Bind function is defined is a Monad
    public static YOption<R> YBind<T, R>(this YOption<T> yOption, Func<T, YOption<R>> func) 
        => yOption.YMatch(() => YNone, func);

    public static YOption<T> YWhere<T>(this YOption<T> yOption, Func<T, bool> predicate) 
        => yOption.YMatch(() => YNone,  t => predicate(t) ? yOption : YNone );
    
    public static IEnumerable<R> YBind<T, R>(this YOption<T> option, Func<T, IEnumerable<R>> func) 
        => option.YAsEnumerable().YBind(func);

    
}