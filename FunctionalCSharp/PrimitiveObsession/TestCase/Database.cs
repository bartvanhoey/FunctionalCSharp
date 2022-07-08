using FunctionalCSharp.NullOptionType;
using FunctionalCSharp.PrimitiveObsession.ValueObjects;

namespace FunctionalCSharp.PrimitiveObsession.TestCase
{
    public class Database : IDatabase
    {
        public void Save(Customer customer)
        {
            Console.WriteLine($"Saving customer {customer.CustomerName.Value} with email {customer.Email.Value} to database");
        }

        public Option<Customer> GetById(int id)
        {
            if (id == -1)
                return Option<Customer>.None;

            var email = Email.Create("MyUserName@hotmail.com");
            var customerName = CustomerName.Create("MyUserName");

            var customer = new Customer(customerName.Type,email.Type);
            return Option<Customer>.From(customer);

        }
    }
}