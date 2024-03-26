using LaYumba.Functional;
using Shouldly;
using Xunit;
using static System.DayOfWeek;
using static LaYumba.Functional.F;

namespace LaYumba.Exercises.Chapter05;

public static class Chap5Ex1
{
    // 1 Write a generic function that takes a string and parses it as a value of an enum. It
    // should be usable as follows:

    // Enum.Parse<DayOfWeek>("Friday") // => Some(DayOfWeek.Friday)
    // Enum.Parse<DayOfWeek>("Freeday") // => None

    // solution: see LaYumba.Functional.Enum.Parse<T>

    private static Option<T> EnumParse<T>(this string s) where T 
        : struct => System.Enum.TryParse(s, out T t ) ? Some(t) : None;


        
    [Theory]
    [InlineData("Monday", Monday)]
    [InlineData("Tuesday", Tuesday)]
    [InlineData("Wednesday", Wednesday)]
    [InlineData("Thursday", Thursday)]
    [InlineData("Friday", Friday)]
    [InlineData("Saturday", Saturday)]
    [InlineData("Sunday", Sunday)]
    public static void Test_EnumParse_With_Correct_Values_Should_Return_Correct_DayOfWeeks(string weekDay, DayOfWeek dayOfWeek)
    {
        var optionFriday = weekDay.EnumParse<DayOfWeek>();
        optionFriday.ShouldBe(Some(dayOfWeek));
        optionFriday.IsSome.ShouldBeTrue();
            
        optionFriday.Match(() => default, x => x).ShouldBe(dayOfWeek);
    }
        
    [Theory]
    [InlineData("Freeday")]
    public static void Test_EnumParse_With_Incorrect_Values_Should_Return_None(string weekDay)
    {
        var optionFriday = weekDay.EnumParse<DayOfWeek>();
        optionFriday.ShouldBe(None);
        optionFriday.IsSome.ShouldBeFalse();
    }

        
    [Theory]
    [InlineData("Freeday", Sunday)]
    public static void Test_Match_EnumParse_With_Incorrect_Values_Should_Return_Default_Sunday(string weekDay, DayOfWeek dayOfWeek)
    {
        var optionFriday = weekDay.EnumParse<DayOfWeek>();
        optionFriday.ShouldBe(None);
        optionFriday.IsSome.ShouldBeFalse();
        optionFriday.Match(() => default, x => x).ShouldBe(dayOfWeek);
    }

    [Theory]
    [InlineData("Monday", Monday)]
    [InlineData("Tuesday", Tuesday)]
    [InlineData("Wednesday", Wednesday)]
    [InlineData("Thursday", Thursday)]
    [InlineData("Friday", Friday)]
    [InlineData("Saturday", Saturday)]
    [InlineData("Sunday", Sunday)]
    public static void Test_LaYumba_Enum_Parse_With_Correct_Values_Should_Return_Correct_DayOfWeeks(string weekDay, DayOfWeek dayOfWeek)
    {
        var optionFriday = weekDay.Parse<DayOfWeek>();
        optionFriday.ShouldBe(Some(dayOfWeek));
        optionFriday.IsSome.ShouldBeTrue();
            
        optionFriday.Match(() => default, x => x).ShouldBe(dayOfWeek);
    }
        
    [Theory]
    [InlineData("Freeday")]
    public static void Test_LaYumba_Enum_Parse_With_Incorrect_Values_Should_Return_None(string weekDay)
    {
        var optionFriday = weekDay.Parse<DayOfWeek>();
        optionFriday.ShouldBe(None);
        optionFriday.IsSome.ShouldBeFalse();
    }

        
    [Theory]
    [InlineData("Freeday", Sunday)]
    public static void Test_LaYumba_Enum_Parse_With_Incorrect_Values_Should_Return_Default_Sunday(string weekDay, DayOfWeek dayOfWeek)
    {
        var optionFriday = weekDay.Parse<DayOfWeek>();
        optionFriday.ShouldBe(None);
        optionFriday.IsSome.ShouldBeFalse();
        optionFriday.Match(() => default, x => x).ShouldBe(dayOfWeek);
    }
}