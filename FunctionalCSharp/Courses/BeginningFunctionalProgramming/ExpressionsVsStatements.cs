namespace FunctionalCSharp.Courses.BeginningFunctionalProgramming;

public class ExpressionsVsStatements
{
    public static void Go()
    {
        var users = new List<User>
        {
            new() {FirstName = "John", LastName = "Doe", Age = 20, IsActive = true},
            new() {FirstName = "Mary", LastName = "Hopkins", Age = 30, IsActive = false},
            new() {FirstName = "Peter", LastName = "Jonsson", Age = 40, IsActive = true},
        };

            
        // Statements
        users.Select(user =>
        {
            string displayName = null;
            if (user.IsActive)
            {
                displayName = $"{user.FirstName} {user.LastName}";
            }
            else
            {
                displayName = $"{user.FirstName} {user.LastName} (Inactive)";
            }

            return displayName;
        }).Print();
            
        // Expressions
        users.Select(u => u.IsActive ? $"{u.FirstName} {u.LastName}" : $"{u.FirstName} {u.LastName} (Inactive)").Print();
            
    }
}