using FunctionalCSharp.Functional.MaybeClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module5_AvoidingNullsWithMaybeType.After
{
    public class Customer
    {
        public Customer(Maybe<CustomerName?> customerName, Maybe<Email?> email)
        {
            if (customerName == null) throw new ArgumentNullException(nameof(customerName));
            if (email == null) throw new ArgumentNullException(nameof(email));
            CustomerName = customerName;
            Email = email;
        }

        public Maybe<CustomerName?> CustomerName { get; set; }
        public Maybe<Email?> Email { get; set; }
    }
}