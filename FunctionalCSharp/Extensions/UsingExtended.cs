namespace FunctionalCSharp.Extensions;

public static class UsingExtended
{
    public static TResult Using<TDisposable, TResult>(Func<TDisposable> factory, Func<TDisposable, TResult> f)
        where TDisposable : IDisposable
    {
        using var disposable = factory();
        return f(disposable);
    }
        
    public static async Task<TResult> UsingAsync<TDisposable, TResult>(
        Func<TDisposable> factory,
        Func<TDisposable, TResult> f)
        where TDisposable : IDisposable
    {
        using var disposable = Task.FromResult(factory()) ;
        return f(await disposable); 
    }
}