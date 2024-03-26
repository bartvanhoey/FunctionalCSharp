using FluentAssertions;
using NUnit.Framework;

namespace LaYumba.Exercises.Chapter02;

public static class ExercisesChapter02
{
    // 1. Write a function  that negates a given predicate: whenvever the given predicate
    // evaluates to `true`, the resulting function evaluates to `false`, and vice versa.
    private static Func<T, bool> MyNegate<T>(this Func<T, bool> isTrueOrFalse) => t => !isTrueOrFalse(t);

    [Test]
    public static void MyNegateFunction()
    {
        Func<int, bool> isEven = x => x % 2 == 0;
            
        var isEvenResult = isEven(10);
        isEvenResult.Should().BeTrue();
            

        var myNegate = isEven.MyNegate();
            
        var isNegateResult = myNegate(10);
        isNegateResult.Should().BeFalse();
    }


    // 2. Write a method that uses quicksort to sort a `List<int>` (return a new list,
    // rather than sorting it in place).

    // 3. Generalize your implementation to take a `List<T>`, and additionally a 
    // `Comparison<T>` delegate.

    // 4. In this chapter, you've seen a `Using` function that takes an `IDisposable`
    // and a function of type `Func<TDisp, R>`. Write an overload of `Using` that
    // takes a `Func<IDisposable>` as first
    // parameter, instead of the `IDisposable`. (This can be used to fix warnings
    // given by some code analysis tools about instantiating an `IDisposable` and
    // not disposing it.)
        
    public static R Using<TDisposable, R>(Func<TDisposable> createDisposable, Func<TDisposable, R> f) 
        where TDisposable : IDisposable
    {
        using var disposable = createDisposable();
        return f(disposable);
    }
}