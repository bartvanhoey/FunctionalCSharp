using Unit = System.ValueTuple;

namespace LaYumba.Functional
{
   using static F;

   public static partial class F
   {
      public static Either.Left<L> Left<L>(L l) => new Either.Left<L>(l);
      public static Either.Right<R> Right<R>(R r) => new Either.Right<R>(r);
   }

   public struct Either<L, R>
   {
      private L? Left { get; }
      private R? Right { get; }

      private bool IsRight { get; }
      private bool IsLeft => !IsRight;

      private Either(L left)
         => (IsRight, Left, Right)
         = (false, left ?? throw new ArgumentNullException(nameof(left)), default);

      private Either(R right)
         => (IsRight, Left, Right)
         = (true, default, right ?? throw new ArgumentNullException(nameof(right)));

      public static implicit operator Either<L, R>(L left) => new(left);
      public static implicit operator Either<L, R>(R right) => new(right);
      public static implicit operator Either<L, R>(Either.Left<L> left) => new(left.Value);
      public static implicit operator Either<L, R>(Either.Right<R> right) => new(right.Value);

      public Tr Match<Tr>(Func<L, Tr> left, Func<R, Tr> right) 
         => IsLeft ? left(Left!) : right(Right!);

      public Unit Match(Action<L> left, Action<R> right) => Match(left.ToFunc(), right.ToFunc());

      public IEnumerator<R> AsEnumerable()
      {
         if (IsRight) yield return Right!;
      }

      public override string ToString() => Match(l => $"Left({l})", r => $"Right({r})");
   }

   public static class Either
   {
      public struct Left<L>
      {
         internal L Value { get; }
         internal Left(L value) { Value = value; }

         public override string ToString() => $"Left({Value})";
      }

      public struct Right<R>
      {
         internal R Value { get; }
         internal Right(R value) { Value = value; }

         public override string ToString() => $"Right({Value})";

         public Right<Rr> Map<L, Rr>(Func<R, Rr> f) => Right(f(Value));
         public Either<L, Rr> Bind<L, Rr>(Func<R, Either<L, Rr>> f) => f(Value);
      }
   }

   public static class EitherExt
   {
      public static Either<L, Rr> Map<L, R, Rr>
         (this Either<L, R> @this, Func<R, Rr> f)
         => @this.Match<Either<L, Rr>>(Left, r => Right(f(r)));

      public static Either<Ll, Rr> Map<L, Ll, R, Rr>(this Either<L, R> @this, Func<L, Ll> left, Func<R, Rr> right)
         => @this.Match<Either<Ll, Rr>>
            (
               l => F.Left(left(l)),
               r => F.Right(right(r))
            );

      public static Either<L, Unit> ForEach<L, R>(this Either<L, R> @this, Action<R> act)
         => Map(@this, act.ToFunc());

      public static Either<L, Rr> Bind<L, R, Rr>(this Either<L, R> @this, Func<R, Either<L, Rr>> f)
         => @this.Match(Left, f);

      // Applicative

      public static Either<L, Rr> Apply<L, R, Rr>
      (
         this Either<L, Func<R, Rr>> @this,
         Either<L, R> valT
      )
      => @this.Match
      (
         left: (errF) => Left(errF),
         right: (f) => valT.Match<Either<L, Rr>>
         (
            right: (t) => Right(f(t)),
            left: (err) => Left(err)
         )
      );

      public static Either<L, Func<T2, R>> Apply<L, T1, T2, R>
         (this Either<L, Func<T1, T2, R>> @this, Either<L, T1> arg)
         => Apply(@this.Map(F.Curry), arg);

      public static Either<L, Func<T2, T3, R>> Apply<L, T1, T2, T3, R>
         (this Either<L, Func<T1, T2, T3, R>> @this, Either<L, T1> arg)
         => Apply(@this.Map(F.CurryFirst), arg);

      public static Either<L, Func<T2, T3, T4, R>> Apply<L, T1, T2, T3, T4, R>
         (this Either<L, Func<T1, T2, T3, T4, R>> @this, Either<L, T1> arg)
         => Apply(@this.Map(F.CurryFirst), arg);

      public static Either<L, Func<T2, T3, T4, T5, R>> Apply<L, T1, T2, T3, T4, T5, R>
         (this Either<L, Func<T1, T2, T3, T4, T5, R>> @this, Either<L, T1> arg)
         => Apply(@this.Map(F.CurryFirst), arg);

      public static Either<L, Func<T2, T3, T4, T5, T6, R>> Apply<L, T1, T2, T3, T4, T5, T6, R>
         (this Either<L, Func<T1, T2, T3, T4, T5, T6, R>> @this, Either<L, T1> arg)
         => Apply(@this.Map(F.CurryFirst), arg);

      public static Either<L, Func<T2, T3, T4, T5, T6, T7, R>> Apply<L, T1, T2, T3, T4, T5, T6, T7, R>
         (this Either<L, Func<T1, T2, T3, T4, T5, T6, T7, R>> @this, Either<L, T1> arg)
         => Apply(@this.Map(F.CurryFirst), arg);

      public static Either<L, Func<T2, T3, T4, T5, T6, T7, T8, R>> Apply<L, T1, T2, T3, T4, T5, T6, T7, T8, R>
         (this Either<L, Func<T1, T2, T3, T4, T5, T6, T7, T8, R>> @this, Either<L, T1> arg)
         => Apply(@this.Map(F.CurryFirst), arg);

      public static Either<L, Func<T2, T3, T4, T5, T6, T7, T8, T9, R>> Apply<L, T1, T2, T3, T4, T5, T6, T7, T8, T9, R>
         (this Either<L, Func<T1, T2, T3, T4, T5, T6, T7, T8, T9, R>> @this, Either<L, T1> arg)
         => Apply(@this.Map(F.CurryFirst), arg);


      // LINQ query pattern

      public static Either<L, R> Select<L, T, R>
      (
         this Either<L, T> @this,
         Func<T, R> f
      )
      => @this.Map(f);

      public static Either<L, Rr> SelectMany<L, T, R, Rr>
      (
         this Either<L, T> @this,
         Func<T, Either<L, R>> bind,
         Func<T, R, Rr> project
      )
      => @this.Match
      (
         left: l => Left(l),
         right: t => bind(t).Match<Either<L, Rr>>
         (
            left: l => Left(l),
            right: r => project(t, r)
         )
      );
   }
}
