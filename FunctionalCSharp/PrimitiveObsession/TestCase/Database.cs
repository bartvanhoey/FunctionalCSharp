namespace FunctionalCSharp.PrimitiveObsession.TestCase
{
    public class Database : IDatabase
    {
        public void Save(Customer customer)
        {
            Console.WriteLine($"Saving customer {customer.CustomerName.Value} with email {customer.Email.Value} to database");
        }
    }
}