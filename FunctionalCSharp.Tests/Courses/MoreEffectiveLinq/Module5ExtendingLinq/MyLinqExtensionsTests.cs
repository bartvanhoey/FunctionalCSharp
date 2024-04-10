using Shouldly;
using FunctionalCSharp.Courses.MoreEffectiveLinq.Module5ExtendingLinq;

namespace FunctionalCSharp.Tests.Courses.MoreEffectiveLinq.Module5ExtendingLinq;

public class MyLinqExtensionsTests
{
    [Fact]
    public void IEnumerable_TimeSpan_Extension_Method_Sum_Should_Return_Correct_TimeSpan()
    {
        var albumDuration = "2:54,3:48,4:51,3:32,6:15,4:08,5:17,3:13,4:16,3:55,4:53,5:35,4:24"
            .Split(',')
            .Select(t => TimeSpan.Parse("0:" + t)).Sum();
        albumDuration.ShouldBe(new TimeSpan(0, 57, 01));
    }
        
    [Fact]
    public void IEnumerable_String_Extension_Method_StringConcat_Should_Return_Correct_Concatenated_String()
    {
        var list = new List<string> {"6","1","3","2","4"};

        var result = list.StringConcat(",");
        result.ShouldBe("6,1,3,2,4");
    }
        
    [Fact]
    public void IEnumerable_String_Extension_Method_MaxBy_Should_Return_Book_With_Most_Pages()
    {
        var books = new[] {
            new { Author = "Robert Martin", Title = "Clean Code", Pages = 464 },
            new { Author = "Oliver Sturm", Title = "Functional Programming in C#" , Pages = 270 },
            new { Author = "Martin Fowler", Title = "Patterns of Enterprise Application Architecture", Pages = 533 },
            new { Author = "Bill Wagner", Title = "Effective C#", Pages = 328 },
        };

        var result = books.MaxBy(x => x.Pages);
        result?.Title.ShouldBe("Patterns of Enterprise Application Architecture");
    }
        
    [Fact]
    public void IEnumerable_String_Extension_Method_CountBy_Should_Count_Dogs_Correctly()
    {
        var result = "Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,Guinea Pig,Dog".Split(",")
            .CountBy(x => x == "Dog" ? x : "other");

        result.Where(x => x.Key == "Dog").Select(x => x.Value).First().ShouldBe(5);
    }

        
    [Fact]
    public void IEnumerable_String_Extension_Method_CountBy_Should_Count_Pets_Correctly()
    {
        var result = "Dog,Cat,Rabbit,Dog,Dog,Lizard,Cat,Cat,Dog,Rabbit,GuineaPig,Dog".Split(",")
            .CountBy(x => x != "Dog" && x != "Cat" ? "Other" : x).ToList();

        result.Where(x => x.Key == "Dog").Select(x => x.Value).First().ShouldBe(5);
        result.Where(x => x.Key == "Cat").Select(x => x.Value).First().ShouldBe(3);
        result.Where(x => x.Key == "Other").Select(x => x.Value).First().ShouldBe(4);
    }

    [Fact]
    public void Calculate_Time_SwimLength()
    {
        const string splitTimes = "00:45,01:32,02:18,03:01,03:44,04:31,05:19,06:01,06:47,07:35";

        var swimLengthTimes = ("00:00," + splitTimes)
            .Split(",")
            .Zip(splitTimes.Split(","),
                (s, f) => new
                {
                    Start = TimeSpan.Parse("00:" + s),
                    End = TimeSpan.Parse("00:" + f)
                }
            ).ToList();

        swimLengthTimes.LastOrDefault()?.Start.ShouldBe(new TimeSpan(0, 6, 47));
        swimLengthTimes.LastOrDefault()?.End.ShouldBe(new TimeSpan(0, 7, 35));
    }
        
        
        
        
        
}