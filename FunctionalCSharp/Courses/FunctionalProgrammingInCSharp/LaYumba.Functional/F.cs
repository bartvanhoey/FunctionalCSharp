namespace FunctionalCSharp.Courses.FunctionalProgrammingInCSharp.LaYumba.Functional
{
    public static class F
    {
        public static TR Using<TDisposable, TR>(TDisposable disposable, Func<TDisposable, TR> func)
            where TDisposable : IDisposable
        {
            using (disposable)
                return func(disposable);
        }
    }
}