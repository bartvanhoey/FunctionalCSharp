using FluentAssertions;
using FunctionalCSharp.MyYumba;
using NUnit.Framework;

namespace LaYumba.Exercises.Chapter02;

public static class ExercisesChapter02
{
    // 1. Write a function  that negates a given predicate: whenever the given predicate
    // evaluates to `true`, the resulting function evaluates to `false`, and vice versa.
    
    // Find YNegate in YFuncExtensions.cs
    
    [Test]
    public static void Test_YNegate_Function()
    {
        Func<int, bool> isEven = x => x % 2 == 0;
            
        var isEvenResult = isEven(10);
        isEvenResult.Should().BeTrue();

        var isNegateResult = isEven.YNegate()(10);
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