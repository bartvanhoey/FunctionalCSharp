using FluentAssertions;
using static FunctionalCSharp.Tests.Functional.LinqExpressions.Aggregate.Employee;

namespace FunctionalCSharp.Tests.Functional.LinqExpressions.Aggregate

{
    public class AggregateMethodTests
    {
        [Fact]
        public void Method_Aggregate_On_A_List_Of_Integers_Should_Return_Correct_Sum()
        {
            IEnumerable<int> ints = new List<int> { 2, 4, 1, 6 };

            var result = ints.Aggregate((sum, val) => sum + val);
            result.Should().Be(13);
        }
        
        [Fact]
        public void Method_Aggregate_On_A_List_Of_Integers_Should_Return_Correct_Product()
        {
            IEnumerable<int> ints = new List<int> { 2, 4, 1, 6 };

            var result = ints.Aggregate((sum, val) => sum * val);
            result.Should().Be(48);
        }
        
        [Fact]
        public void Method_Aggregate_On_A_List_Of_String_Should_Return_Correct_Concatenated()
        {
            IEnumerable<string> strings = new List<string> { "a", "ab", "abc", "abcd", "z"};

            var result = strings.Aggregate((concat, str) => $"{concat}&{str}");
            result.Should().Be("a&ab&abc&abcd&z");
        }
        
        [Fact]
        public void Method_Aggregate_On_A_List_Of_String_Should_Return_Comma_Separated_List()
        {
            var strings = new List<string> { "C#.NET", "MVC", "WCF", "SQL", "LINQ", "ASP.NET"};

            var result = strings.Aggregate((concat, str) => $"{concat},{str}");
            result.Should().Be("C#.NET,MVC,WCF,SQL,LINQ,ASP.NET");
        }
        
        [Fact]
        public void Method_Aggregate_On_A_List_Of_String_Should_Return_Correct_Count_Of_Strings()
        {
            IEnumerable<string> strings = new List<string> { "a", "ab", "abc", "abcd", "z"};

            var result = strings.Aggregate(0, (count, _) => count+1);
            result.Should().Be(5);
        }
        
        [Fact]
        public void Method_Aggregate_On_A_List_Of_String_Should_Return_Correct_Total_Characters()
        {
            IEnumerable<string> strings = new List<string> { "a", "ab", "abc", "abcd", "z"};

            var result = strings.Aggregate(0, (count, val) => count + val.Length);
            result.Should().Be(11);
        }
        
        [Fact]
        public void Method_Aggregate_On_A_List_Of_String_Should_Return_True_When_Check_Length_Greater_Then_3()
        {
            IEnumerable<string> strings = new List<string> { "a", "ab", "abc", "abcd", "z"};

            var result = strings.Aggregate(false, (any, val) => any || val.Length > 3);
            result.Should().BeTrue();
        }

        [Fact]
        public void Method_Aggregate_On_A_List_Of_Employees_Should_Return_The_Total_Salary_Of_All()
        {
            var result = GetEmployees().Aggregate(0, (totalSalary, emp) => totalSalary + emp.Salary);
            result.Should().Be(125000);
        }
        
        [Fact]
        public void Method_Aggregate_On_A_List_Of_Employees_Should_Return_All_The_Employee_Names()
        {
            var result = GetEmployees().Aggregate("Employee Names: ", (names, emp) => names + emp.Name  + ", ");
            result.Should().Be("Employee Names: Preety, Priyanka, James, Hina, Anurag, ");
        }
        
        [Fact]
        public void Method_Aggregate_On_A_List_Of_Employees_Should_Return_Employee_With_Highest_Salary()
        {
            var result = GetEmployees().Aggregate((agg, next) => next.Salary > agg.Salary ? next : agg);
            result.Name.Should().Be("James");
        }
        
        
        [Fact]
        public void Method_Aggregate_Should_Calculate_Correct_Album_Duration()
        {
            var albumDuration = "2:54,3:48,4:51,3:32,6:15,4:08,5:17,3:13,4:16,3:55,4:53,5:35,4:24"
                .Split(',')
                .Select(t => TimeSpan.Parse("0:" + t))
                .Aggregate((t1, t2) => t1 + t2);

            albumDuration.Should().Be(new TimeSpan(0, 57, 01));
        }
        
    }
}