using FunctionalCSharp.Functional.MaybeType;
using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.ErrorsAndFailures.TestCase
{
    public interface IDatabase
    {
        Maybe<Customer> GetById(int id);
        Result Save(Customer customer);
    }
}