namespace LaYumba.Functional.Traversable;

using static F;

public static class OptionTraversable
{
   // Exceptional
   public static Exceptional<Option<R>> Traverse<T, R>
      (this Option<T> tr, Func<T, Exceptional<R>> f)
      => tr.Match(
         none: () => Exceptional((Option<R>)None),
         some: t => f(t).Map(Some)
      );

   // Task
   public static Task<Option<R>> Traverse<T, R>
      (this Option<T> @this, Func<T, Task<R>> func)
      => @this.Match(
         none: () => Async((Option<R>)None),
         some: t => func(t).Map(Some)
      );

   public static Task<Option<R>> TraverseBind<T, R>(this Option<T> @this
      , Func<T, Task<Option<R>>> func)
      => @this.Match(
         none: () => Async((Option<R>)None),
         some: t => func(t)
      );
}