using Unit = System.ValueTuple;

namespace FunctionalCSharp.Extensions
{
    public static class YumbaFunctionalExtensions
    {
        public static Tr Using<TDisposable, Tr>(TDisposable disposable, Func<TDisposable, Tr> func)
            where TDisposable : IDisposable
        {
            using (disposable) return func(disposable);
        }

        public static Unit Unit() => default;
    }
}