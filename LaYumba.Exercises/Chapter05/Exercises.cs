// using FluentAssertions;
// using LaYumba.Functional;
// using NUnit.Framework;
// using static System.DayOfWeek;
// using static LaYumba.Functional.F;
// using static NUnit.Framework.Assert;
//
// namespace LaYumba.Exercises.Chapter05
// {
//     public static class Exercises
//     {
//         // 1 Write a generic function that takes a string and parses it as a value of an enum. It
//         // should be usable as follows:
//
//         private static Option<T> MyParseToEnum<T>(this string s) where T : struct
//             => System.Enum.TryParse(s, out T t) ? Some(t) : None;
//
//         private static Option<T> MyLookup<T>(this IEnumerable<T> ts, Func<T, bool> isTrue)
//         {
//             foreach (var t in ts) if (isTrue(t)) return Some(t);
//             return None;
//         }
//
//
//         [Test]
//         public static void Test_MyLookup_Method()
//         {
//             bool IsOdd(int x) => x % 2 == 1;
//
//             var myLookup1 = Enumerable.Range(1, 10).OrderBy(x => x).MyLookup(IsOdd);
//
//             myLookup1.Should().BeEquivalentTo(Some(1));
//
//             var myLookup2 = new List<int>().OrderBy(x => x).MyLookup(x => x % 2 == 1);
//             // Assert.Equals(myLookup2, None);
//             
//             var myLookup3 = Enumerable.Range(2, 10).OrderBy(x => x).MyLookup(x => x % 2 == 1);
//             // Assert.Equals(myLookup3, Some(3));
//         }
//
//
//         [Test]
//         public static void Test_MyParseToEnum_Method()
//         {
//             var optionFriday = "Friday".MyParseToEnum<DayOfWeek>();
//             // Assert.Equals(optionFriday, Some(Friday));
//             // Assert.Equals(optionFriday.IsSome, true);
//             var friday = optionFriday.Match(() => default, x => x);
//             // Assert.Equals(Friday, friday);
//
//             var optionFreeday = "Freeday".MyParseToEnum<DayOfWeek>();
//             // Assert.Equals(optionFreeday, None);
//             // Assert.Equals(optionFreeday.IsSome, false);
//             var sunday = optionFreeday.Match(() => default, x => x);
//             // Assert.Equals(Sunday, sunday);
//         }
//
//
//         [Test]
//         public static void Test_LaYumba_Functional_Enum_Parse_Method()
//         {
//             var optionFriday = "Friday".Parse<DayOfWeek>();
//             optionFriday.Should().Be(Some(Friday));
//             optionFriday.IsSome.Should().BeTrue();
//             
//             var friday = optionFriday.Match(() => default, x => x);
//             
//             friday.Should().Be(Friday);
//             var optionFreeday = "Freeday".Parse<DayOfWeek>();
//             optionFreeday.Should().Be(None);
//             optionFriday.IsSome.Should().BeFalse();
//             
//             var sunday = optionFreeday.Match(() => default, x => x);
//             Sunday.Should().Be(sunday);
//         }
//
//
//         // Enum.Parse<DayOfWeek>("Freeday") // => None
//
//         // 2 Write a Lookup function that will take an IEnumerable and a predicate, and
//         // return the first element in the IEnumerable that matches the predicate, or None
//         // if no matching element is found. Write its signature in arrow notation:
//
//         // bool isOdd(int i) => i % 2 == 1;
//         // new List<int>().Lookup(isOdd) // => None
//         // new List<int> { 1 }.Lookup(isOdd) // => Some(1)
//
//         // 3 Write a type Email that wraps an underlying string, enforcing that it’s in a valid
//         // format. Ensure that you include the following:
//         // - A smart constructor
//         // - Implicit conversion to string, so that it can easily be used with the typical API
//         // for sending emails
//
//         // 4 Take a look at the extension methods defined on IEnumerable inSystem.LINQ.Enumerable.
//         // Which ones could potentially return nothing, or throw some
//         // kind of not-found exception, and would therefore be good candidates for
//         // returning an Option<T> instead?
//     }
// }