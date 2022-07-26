using FunctionalCSharp.Functional.MaybeType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.PrimitiveObsession.TestCase
{
    public interface IDatabase
    {
        void Save(Customer customer);
        Maybe<Customer> GetById(int id);
    }
}