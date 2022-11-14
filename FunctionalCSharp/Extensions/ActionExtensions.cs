using Unit = System.ValueTuple;

namespace FunctionalCSharp.Extensions
{
    public static class ActionExtensions
    {
        public static Func<Unit> ToFunc(this Action action) 
            => () =>
        {
            action();
            return default;
        };
        
        public static Func<T, Unit> ToFunc<T>(this Action<T> action) => t =>
        {
            action(t);
            return default;
        };
    }
}