using FluentAssertions;

namespace FunctionalCSharp.Tests.Functional.LinqExpressions.Lambda
{
    public class LambdasTests
    {
        [Fact]
        public void Test()
        {
            var days = Enum.GetValues(typeof(DayOfWeek)).Cast<DayOfWeek>();

            IEnumerable<DayOfWeek> DaysStartingWith(string pattern)
                => days.Where(d => d.ToString().StartsWith(pattern));
            
            var dayOfWeeks = DaysStartingWith("S").ToList();
            
            dayOfWeeks.Should().Contain(DayOfWeek.Sunday);
            dayOfWeeks.Should().Contain(DayOfWeek.Saturday);


        }  
    }
}