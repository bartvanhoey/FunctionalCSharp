namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.PrimitiveObsession.TestCase
{
    public class CustomerModel
    {
        public CustomerModel(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public string Name { get; }
        public string Email { get; }
    }
}