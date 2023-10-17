namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.Before
{
    public class Database
    {
        public Customer? GetById(int customerId)
        {
            var customer = new Customer {BillingInfo = "1234", Id = customerId};
            return customer;
        }

        public void Save(Customer customer)
        {
            var random = new Random();
            var randomValue = random.Next(0, 1);
            if (randomValue == 1) throw new SqlException();
        }
    }
}