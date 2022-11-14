namespace FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module2ExpressYourself
{
    public static class DisposableUsing
    {
        public static TResult Using<TDisposable, TResult>(Func<TDisposable> factory, Func<TDisposable, TResult> map)
            where TDisposable : IDisposable
        {
            using var disposable = factory();
                return map(disposable);
        }
        
        public static async Task<TResult> UsingAsync<TDisposable, TResult>(
            Func<TDisposable> factory,
            Func<TDisposable, TResult> map)
            where TDisposable : IDisposable
        {
            using var disposable = Task.FromResult(factory()) ;
            return map(await disposable); 
        }
    }
}