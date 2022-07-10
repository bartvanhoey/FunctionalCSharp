using FunctionalCSharp.Exceptions.ResultClass;
using FunctionalCSharp.NullOptionType;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.ErrorsAndFailures.TestCase
{
    public interface IDatabase
    {
        Maybe<Customer> GetById(int id);
        Result Save(Customer customer);
    }
}