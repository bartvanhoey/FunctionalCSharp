using Unit = System.ValueTuple;

namespace FunctionalCSharp.Extensions
{
    public static class YumbaFunctionalExtensions
    {
        public static TR Using<TDisposable, TR>(TDisposable disposable, Func<TDisposable, TR> func)
            where TDisposable : IDisposable
        {
            using (disposable)
                return func(disposable);
        }

        public static Unit Unit() => default;
    }
}