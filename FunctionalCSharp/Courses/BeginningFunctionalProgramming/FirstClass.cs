using static FunctionalCSharp.Courses.BeginningFunctionalProgramming.FunctionExtensions;

namespace FunctionalCSharp.Courses.BeginningFunctionalProgramming
{
    public class FirstClass
    {
        public static void Go()
        {
            var users = new List<User>
            {
                new() {FirstName = "John", LastName = "Doe", Age = 20, IsActive = true},
                new() {FirstName = "Mary", LastName = "Hopkins", Age = 30, IsActive = false},
                new() {FirstName = "Peter", LastName = "Jonsson", Age = 40, IsActive = true},
            };

            
            // 1. users.Where(u => u.IsActive).Select(u => $"{u.FirstName} {u.LastName}").Print();
            
            // 2.
            // Func<User, bool> areActiveUsers = u => u.IsActive;
            // Func<User, string> fullName = u => $"{u.FirstName} {u.LastName}";
            // users.Where(areActiveUsers).Select(fullName).Print();

            // 3. local functions
            // bool AreActiveUsers(User u) => u.IsActive;
            // string FullName(User u) => $"{u.FirstName} {u.LastName}";
            // users.Where(AreActiveUsers).Select(FullName).Print();

            // 4. Move local function to a static class
            users.Where(IsActive).Select(FirstNameLastName).Print();
        }
    }

    public static class FunctionExtensions
    {
        public static bool IsActive(User u) => u.IsActive;
        public static string FirstNameLastName(User u) => $"{u.FirstName} {u.LastName}";
    }
    
    
    public static class EnumerableExtensions
    {
        public static void Print<T>(this IEnumerable<T> items)
        {
            foreach (var item in items) Console.WriteLine(item);
            
        }
    }
}