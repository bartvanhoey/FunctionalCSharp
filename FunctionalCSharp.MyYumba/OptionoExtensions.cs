using static FunctionalCSharp.MyYumba.Y;
using Unit = System.ValueTuple;

namespace FunctionalCSharp.MyYumba;

public static class OptionoExtensions {
    
    // MAP (C<T>, (T -> R)) -> C<R>
    // in FP, a type for which a Map function is defined is a Functor
    // Map should apply a function to the container's inner vale,
    // and should do nothing else (should have no side effects)
    public static Optiono<R> YMap<T, R>(this Optiono<T> optiono, Func<T, R> func) 
        => optiono.YMatch(() => Nono, x => Somo(func(x)));

    // FOREACH is similar to MAP but takes an Action instead of a Function => used for its side effects
    public static Optiono<Unit> YForEach<T>(this Optiono<T> optiono, Action<T> action)
        => optiono.YMap(action.YToFunc());


    // BIND takes an Option-returning function and applies the function to the inner value of the option
    public static Optiono<R> YBind<T, R>(this Optiono<T> optiono, Func<T, Optiono<R>> func) 
        => optiono.YMatch(() => Nono, func);
}