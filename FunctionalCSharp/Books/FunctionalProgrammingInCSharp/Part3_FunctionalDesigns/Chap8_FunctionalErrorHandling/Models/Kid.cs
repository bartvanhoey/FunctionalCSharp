namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.Models
{
    public class Kid
    {
        public Kid(int age, string? firstName, string? lastName)
        {
            Age = age;
            FirstName = firstName ?? "First name not set";
            LastName = lastName ?? "First name not set";;
        }

        public int Age { get; }
        public string? FirstName { get; }
        public string? LastName { get; }
    
    }
}