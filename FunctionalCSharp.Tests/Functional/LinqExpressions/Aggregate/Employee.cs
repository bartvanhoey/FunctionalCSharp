// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace FunctionalCSharp.Tests.Functional.LinqExpressions.Aggregate;

public  class Employee
{
    public int Id { get; set; }
    public string? Name { get; set; }
    public int Salary { get; set; }
    public string? Department { get; set; }

    public static IEnumerable<Employee> GetEmployees()
    {
        return new List<Employee>
        {
            new() { Id = 101, Name = "Preety", Salary = 10000, Department = "IT" },
            new() { Id = 102, Name = "Priyanka", Salary = 15000, Department = "Sales" },
            new() { Id = 103, Name = "James", Salary = 50000, Department = "Sales" },
            new() { Id = 104, Name = "Hina", Salary = 20000, Department = "IT" },
            new() { Id = 105, Name = "Anurag", Salary = 30000, Department = "IT" },
        };
    }
}