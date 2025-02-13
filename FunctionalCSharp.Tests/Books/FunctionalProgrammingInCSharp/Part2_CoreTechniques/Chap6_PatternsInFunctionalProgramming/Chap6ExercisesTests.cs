using Shouldly;
using FunctionalCSharp.MyYumba;
using static FunctionalCSharp.MyYumba.Y;
using static FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.
    Chap6_PatternsInFunctionalProgramming.EmployeeHelper;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.
    Chap6_PatternsInFunctionalProgramming;

public class Chap6ExercisesTests
{
    [Fact]
    public void Method_GetWorkPermit_Should_Return_Correct_Values()
    {
        var workPermitEmployee1 = GetWorkPermit(GetEmployeesDictionary, "1");
        workPermitEmployee1.ShouldNotBe(YNone);

        var workPermitEmployee2 = GetWorkPermit(GetEmployeesDictionary, "2");
        workPermitEmployee2.ShouldBe(YNone);
    }

    

    [Fact]
    public void Method_GetAverageYearsWorkedAtTheCompany_Should_Return_Correct_Values()
    {
        var averageYears = GetAverageYearsWorkedAtTheCompany(GetEmployeeList);
        averageYears.ShouldBe(0.99726027397260275);
    }

    private static YOption<WorkPermit> GetWorkPermit(Dictionary<string, Employee> employees, string employeeId)
        => employees.YLookup(employeeId).YBind(e => e.WorkPermit);

    private static YOption<WorkPermit> GetValidWorkPermit(Dictionary<string, Employee> employees, string employeeId)
        => employees.YLookup(employeeId)
            .YBind(e => e.WorkPermit)
            .YWhere(HasWorkPermitExpired.YNegate());

    private static double GetAverageYearsWorkedAtTheCompany(IEnumerable<Employee> employees)
    {
        var average = employees.YBind(e => OptExt.YMap(e.LeftOn, leftOn => YearsBetween(e.JoinedOn, leftOn))).Average();

        return average;
    }


    private static Func<WorkPermit, bool> HasWorkPermitExpired => permit => permit.Expiry < DateTime.Now.Date;

    static double YearsBetween(DateTime start, DateTime end) => (end - start).Days / 365d;
}

public record Employee(string Id, YOption<WorkPermit> WorkPermit, DateTime JoinedOn, YOption<DateTime> LeftOn);

public record WorkPermit(string Number, DateTime Expiry);

public static class EmployeeHelper
{
    public static Dictionary<string, Employee> GetEmployeesDictionary = new()
    {
        {
            "1", new Employee("1", YSome(new WorkPermit("1", new DateTime(2014, 12, 31))), new DateTime(2010, 1, 1),
                YSome(new DateTime(2010, 12, 31)))
        },
        {
            "2", new Employee("2", YNone, new DateTime(2010, 1, 1),
                YSome(new DateTime(2010, 12, 31)))
        },
        {
            "3", new Employee("3", YSome(new WorkPermit("1", new DateTime(2014, 12, 31))), new DateTime(2010, 1, 1),
                YNone
            )
        },
        {
            "4",
            new Employee("4", YSome(new WorkPermit("1", new DateTime(2024, 12, 31))), new DateTime(2010, 1, 1), YNone)
        },
    };
    
    public static List<Employee> GetEmployeeList =
    [
        new Employee("1", YSome(new WorkPermit("1", new DateTime(2014, 12, 31))), new DateTime(2010, 1, 1),
            YSome(new DateTime(2010, 12, 31))),

        new Employee("2", YNone, new DateTime(2010, 1, 1),
            YSome(new DateTime(2010, 12, 31))),

        new Employee("3", YSome(new WorkPermit("1", new DateTime(2014, 12, 31))), new DateTime(2010, 1, 1),
            YNone
        ),

        new Employee("4", YSome(new WorkPermit("1", new DateTime(2024, 12, 31))), new DateTime(2010, 1, 1), YNone)
    ];
}

public static class OptExt
{
    public static YOption<R> YMap<T, R>(this YOption<T> opt, Func<T, R> func)
        => opt.YBind(t => Y.YSome(func(t)));
}