using System.Text;
using FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module2_ExpressYourself;
using static System.DateTime;

namespace FunctionalCSharp.Tests.Courses.FunctionalProgrammingWithCSharp.Module2_ExpressYourself;

public class EnforcingImmutabilityTests
{
    private readonly List<DateTime> _testDates =
    [
        Parse("2015-11-03"),
        Parse("2015-11-01"),
        Parse("2015-10-01"),
        Parse("2015-12-01")
    ];

    private readonly StringBuilder _builder = new();

    [Fact]
    public void TestFunctionalDateRangeClass()
    {
        var range = new DateRangeFunctional(Parse("2015-11-01"), Parse("2015-11-06"));

        foreach (var testDate in _testDates) 
            _builder.AppendLine($"{testDate:yy-MM-dd} - {range.DateIsInRange(testDate)}");

        var outputRange = _builder.ToString();

        var newRange = range.Slide(10);
        _builder.Clear();
        
        foreach (var testDate in _testDates) 
            _builder.AppendLine($"{testDate:yy-MM-dd} - {newRange.DateIsInRange(testDate)}");

        var outputNewRange = _builder.ToString();
    }


    [Fact]
    public void TestNonFunctionalDateRangeClass()
    {
        var range = new DateRange { Start = Parse("2015-11-01"), End = Parse("2015-11-06") };

        foreach (var testDate in _testDates)
            _builder.AppendLine($"{testDate:yy-MM-dd} - {range.DateIsInRange(testDate)}");

        var output1 = _builder.ToString();

        range.End = MaxValue;
        _builder.Clear();
        foreach (var testDate in _testDates) 
            _builder.AppendLine($"{testDate:yy-MM-dd} - {range.DateIsInRange(testDate)}");

        var output2 = _builder.ToString();
    }
}