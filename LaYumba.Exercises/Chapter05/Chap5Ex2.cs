using FluentAssertions;
using LaYumba.Functional;
using Shouldly;
using Xunit;
using static LaYumba.Functional.F;

namespace LaYumba.Exercises.Chapter05;

public static class Chap5Ex2
{
    // 2 Write a Lookup function that will take an IEnumerable and a predicate, and
    // return the first element in the IEnumerable that matches the predicate, or None
    // if no matching element is found. Write its signature in arrow notation:

    // bool isOdd(int i) => i % 2 == 1;
    // new List<int>().Lookup(isOdd) // => None
    // new List<int> { 1 }.Lookup(isOdd) // => Some(1)

    // Lookup : IEnumerable<T> -> (T -> bool) -> Option<T>
    private static Option<T> MyLookup<T>(this IEnumerable<T> items, Func<T, bool> isTrue)
    {
        foreach (var item in items)
            if (isTrue(item)) return Some(item);
        return None;
    }
    
    [Fact]
    public static void Test_MyLookup_Method()
    {
        var myLookup1 = Enumerable.Range(1, 10).OrderBy(x => x).MyLookup(IsOdd);
        myLookup1.Should().BeEquivalentTo(Some(1));

        var myLookup2 = new List<int>().OrderBy(x => x).MyLookup(x => x % 2 == 1);
        myLookup2.ShouldBe(None);
        
        var myLookup3 = Enumerable.Range(2, 10).OrderBy(x => x).MyLookup(x => x % 2 == 1);
        myLookup3.ShouldBe( Some(3));
    }
    
    private static bool IsOdd(int x) => x % 2 == 1;
}
