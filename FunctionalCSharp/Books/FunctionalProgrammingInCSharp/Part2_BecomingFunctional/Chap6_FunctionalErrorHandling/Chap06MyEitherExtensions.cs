using System.Reactive;
using LaYumba.Functional;
using static LaYumba.Functional.F;
using Unit = System.ValueTuple;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling;

public static class Chap06MyEitherExtensions
{
    public static Either<L, Rr> MyMap<L, R, Rr>(this Either<L, R> either, Func<R, Rr> f) 
        => either.Match<Either<L, Rr>>(Left, r => Right(f(r)));

    public static Either<L, Unit> MyForEach<L, R>(this Either<L, R> either, Action<R> action) 
        => MyMap(either, action.ToFunc());

    public static Either<L, Rr> MyBind<L, R, Rr>(this Either<L, R> either, Func<R, Either<L, Rr>> f) 
        => either.Match(Left, f);
}