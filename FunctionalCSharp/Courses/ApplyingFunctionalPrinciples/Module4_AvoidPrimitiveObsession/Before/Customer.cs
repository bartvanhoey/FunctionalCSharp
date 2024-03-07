using System.Text.RegularExpressions;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.Before
{
    public class Customer
    {
        public string Name { get; private set; }
        public string Email { get; private set; }
        public Customer(string name, string email)
        {
            Name = name;
            Email = email;
        }

        public void ChangeName(string name)
        {
            // validate name
            if (string.IsNullOrWhiteSpace(name) || name.Trim().Length > 50)
                throw new ArgumentException("Name is invalid");
            Name = name;
        }
        
        public void ChangeEmail(string email)
        {
            // validate email
            if (string.IsNullOrWhiteSpace(email) || email.Length > 100)
                throw new ArgumentException("Email is invalid");
            if (!Regex.IsMatch(email, @"^(.+)@(.+)$"))
                throw new ArgumentException("Email is invalid");
            Email = email;
        }
    }
}