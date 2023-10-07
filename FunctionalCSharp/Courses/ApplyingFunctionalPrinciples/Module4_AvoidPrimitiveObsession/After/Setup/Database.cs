using FunctionalCSharp.Functional.MaybeClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After.Setup
{
    public class Database : IDatabase
    {
        public void Save(Customer customer)
        {
            Console.WriteLine(
                $"Saving customer {customer.CustomerName.Value} with email {customer.Email.Value} to database");
        }

        public Maybe<Customer> GetById(int id)
        {
            if (id == -1)
                return Maybe<Customer>.None;

            var email = Email.CreateEmail("MyUserName@hotmail.com");
            var customerName = CustomerName.Create("MyUserName");

            var customer = new Customer(customerName.Type, email.Type);
            return Maybe<Customer>.From(customer);
        }
    }
}