namespace FunctionalCSharp.Courses.BeginningFunctionalProgramming;

public class Composition
{
    public static void Go()
    {
        var users = new List<User>
        {
            new() {FirstName = "John", LastName = "Doe", Age = 20, IsActive = true},
            new() {FirstName = "Mary", LastName = "Hopkins", Age = 30, IsActive = false},
            new() {FirstName = "Peter", LastName = "Jonsson", Age = 40, IsActive = true},
        };
    }
}