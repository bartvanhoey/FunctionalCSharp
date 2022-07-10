using FunctionalCSharp.PrimitiveObsession.ValueObjects;

namespace FunctionalCSharp.PrimitiveObsession
{
    public class Customer
    {
        public CustomerName CustomerName { get;  set; }
        public Email Email { get; set; }

        public Customer(CustomerName customerName, Email email)
        {
            // if (customerName == null) throw new ArgumentNullException(nameof(customerName));
            // if (email == null) throw new ArgumentNullException(nameof(email));
            CustomerName = customerName;
            Email = email;
        }

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