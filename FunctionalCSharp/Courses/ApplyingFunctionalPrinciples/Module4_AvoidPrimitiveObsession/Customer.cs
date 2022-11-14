using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.ValueObjects;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession
{
    public class Customer
    {
        public Customer(CustomerName customerName, Email email)
        {
            // if (customerName == null) throw new ArgumentNullException(nameof(customerName));
            // if (email == null) throw new ArgumentNullException(nameof(email));
            CustomerName = customerName;
            Email = email;
        }

        public CustomerName CustomerName { get; set; }
        public Email Email { get; set; }

        // public void ChangeName(CustomerName name)
        // {
        //     // if (name == null) throw new ArgumentNullException(nameof(name));
        //     CustomerName = name;
        // }
        //
        // public void ChangeEmail(Email email)
        // {
        //     // if (email == null) throw new ArgumentNullException(nameof(email));
        //     Email = email;
        // }
    }
}