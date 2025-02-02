

using CSharpFunctionalExtensions;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After;

public interface IDatabase
{
    Maybe<Customer?> GetById(int customerId);
    Result Save(Customer customer);
}

public class Database : IDatabase
{
    public Maybe<Customer?> GetById(int customerId)
    {
        var random = new Random();
        var randomValue = random.Next(0, 1);
        return randomValue == 1
            ? null
            : Maybe.From(new Customer { BillingInfo = "1234", Id = customerId });
    }

    public Result Save(Customer customer)
    {
        try
        {
            var random = new Random();
            var randomValue = random.Next(0, 1);
            if (randomValue == 1) throw new SqlException();
        }
        catch (Exception e)
        {
            return Result.Failure("");
        }
        return Result.Success();
            
    }
}