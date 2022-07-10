using FunctionalCSharp.Functional;
using FunctionalCSharp.Functional.Maybe;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.ErrorsAndFailures.TestCase
{
    public interface IDatabase
    {
        Maybe<Customer> GetById(int id);
        Result Save(Customer customer);
    }
}