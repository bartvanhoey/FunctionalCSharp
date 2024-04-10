using Shouldly;
using FunctionalCSharp.MyYumba;
using Shouldly;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.
    Chap6_PatternsInFunctionalProgramming;

public class Chap6ExercisesGetWorkPermitTests
{
    [Fact]
    public void Method_GetWorkPermit_Should_Return_Correct_Values()
    {
        var employees = new Dictionary<string, Employee>
        {
            {
                "1",  new Employee("1", Y.YSome(new WorkPermit("1", new DateTime(2014, 12, 31))), new DateTime(2010,1,1),
                    Y.YSome(new DateTime(2010, 12, 31)))
            },
            {
                "2",  new Employee("2", Y.YNone, new DateTime(2010,1,1),
                    Y.YSome(new DateTime(2010, 12, 31)))
            },
            {
                "3",  new Employee("3", Y.YSome(new WorkPermit("1", new DateTime(2014, 12, 31))), new DateTime(2010,1,1),
                    Y.YSome(new DateTime(2010, 12, 31)))
            }
        };

        var workPermitEmployee1 = GetWorkPermit(employees, "1");
        workPermitEmployee1.ShouldNotBe(Y.YNone);
        
        var workPermitEmployee2 = GetWorkPermit(employees, "2");
        
        workPermitEmployee2.ShouldBe(Y.YNone);
    }


    private static YOption<WorkPermit> GetWorkPermit(Dictionary<string, Employee> employees, string employeeId)
        => employees.YLookup(employeeId).YBind(e => e.WorkPermit);

    private static YOption<WorkPermit> GetValidWorkPermit(Dictionary<string, Employee> employees, string employeeId)
        => employees.YLookup(employeeId)
            .YBind(e => e.WorkPermit)
            .YWhere(HasWorkPermitExpired.YNegate());

    private static Func<WorkPermit, bool> HasWorkPermitExpired => permit => permit.Expiry < DateTime.Now.Date;
}

public record Employee(string Id, YOption<WorkPermit> WorkPermit, DateTime JoinedOn, YOption<DateTime> LeftOn);

public record WorkPermit(string Number, DateTime Expiry);