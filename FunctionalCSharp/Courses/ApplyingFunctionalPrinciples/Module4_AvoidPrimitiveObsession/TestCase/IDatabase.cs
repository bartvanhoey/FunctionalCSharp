using FunctionalCSharp.Functional.MaybeClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.TestCase
{
    public interface IDatabase
    {
        void Save(Customer customer);
        Maybe<Customer> GetById(int id);
    }
}