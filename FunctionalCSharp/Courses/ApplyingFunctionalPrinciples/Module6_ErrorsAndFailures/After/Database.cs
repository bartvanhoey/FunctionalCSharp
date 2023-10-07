using FunctionalCSharp.Functional.MaybeClass;
using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After
{
    public class Database
    {
        public Maybe<Customer> GetCustomer(int customerId)
        {
            var customer = new Customer {BillingInfo = "1234", Id = customerId};
            return Maybe.From(customer);
        }

        public Result Save(Customer customer)
        {
            try
            {
                var random = new Random();
                var randomValue = random.Next(0, 2);
                if (randomValue == 1) throw new SqlException();
            }
            catch (Exception exception)
            {
                return Result.Fail(new SqlSaveResultError("Unable to connect to the database"));
            }

            Console.WriteLine($"Customer {customer.Balance} saved");

            return Result.Ok();
        }
    }

    public class SqlSaveResultError : BaseResultError
    {
        public SqlSaveResultError(string message) : base(message)
        {
        }
    }
}