using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling
{
    public static class MyEitherExtensions
    {
        // ReSharper disable once ConvertClosureToMethodGroup
        public static Either<L, Rr> MyMap<L, R, Rr>(this Either<L, R> either, Func<R, Rr> func)
            => either.Match<Either<L, Rr>>(l => F.Left(l), r => F.Right(func(r)));
    
        // ReSharper disable once ConvertClosureToMethodGroup
        public static Either<L, Rr> MyBind<L, R, Rr>(this Either<L, R> either, Func<R, Either<L,Rr>> func)
            => either.Match<Either<L, Rr>>(l => F.Left(l), r => func(r) );
    
        public static Either<L, ValueTuple> ForEach<L, R>(this Either<L, R> either, Action<R> act)
            => MyMap(either, act.ToFunc());
    
        public static string RenderToString<L,R>(this Either<L, R> either) 
            => either.Match(x => $"Invalid Value: {x}", x => $"The result is: {x}");
    }
}