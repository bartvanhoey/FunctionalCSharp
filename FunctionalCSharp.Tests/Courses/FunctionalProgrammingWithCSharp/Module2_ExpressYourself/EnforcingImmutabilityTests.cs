using System.Text;
using FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module2_ExpressYourself;

namespace FunctionalCSharp.Tests.Courses.FunctionalProgrammingWithCSharp.Module2_ExpressYourself
{
    public class EnforcingImmutabilityTests
    {
        private readonly List<DateTime> _testDates = new()
        {
            DateTime.Parse("2015-11-03"),
            DateTime.Parse("2015-11-01"),
            DateTime.Parse("2015-10-01"),
            DateTime.Parse("2015-12-01")
        };

        private readonly StringBuilder _builder = new();

        [Fact]
        public void TestFunctionalDateRangeClass()
        {
            var range = new DateRangeFunctional(DateTime.Parse("2015-11-01"), DateTime.Parse("2015-11-06"));

            foreach (var testDate in _testDates)
            {
                _builder.AppendLine($"{testDate:yy-MM-dd} - {range.DateIsInRange(testDate)}");
            }

            var outputRange = _builder.ToString();
            
            var newRange = range.Slide(10);
            _builder.Clear();
            foreach (var testDate in _testDates)
            {
                _builder.AppendLine($"{testDate:yy-MM-dd} - {newRange.DateIsInRange(testDate)}");
            }
            var outputNewRange = _builder.ToString();
            
        }


        [Fact]
        public void TestNonFunctionalDateRangeClass()
        {
            var range = new DateRange {Start = DateTime.Parse("2015-11-01"), End = DateTime.Parse("2015-11-06")};

            foreach (var testDate in _testDates)
            {
                _builder.AppendLine($"{testDate:yy-MM-dd} - {range.DateIsInRange(testDate)}");
            }

            var output1 = _builder.ToString();

            range.End = DateTime.MaxValue;
            _builder.Clear();            
            foreach (var testDate in _testDates)
            {
                _builder.AppendLine($"{testDate:yy-MM-dd} - {range.DateIsInRange(testDate)}");
            }
            var output2 = _builder.ToString();
        }
    }
}