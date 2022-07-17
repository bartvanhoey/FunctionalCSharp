using FunctionalCSharp.Functional;
using FunctionalCSharp.Functional.MaybeType;
using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.ErrorsAndFailures.TestCase
{
    public interface IDatabase
    {
        Maybe<Customer> GetById(int id);
        Result Save(Customer customer);
    }
}