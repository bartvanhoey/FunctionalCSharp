using FunctionalCSharp.Functional.MaybeClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module5_AvoidingNullsWithMaybeType.After.Setup
{
    public interface IDatabase
    {
        void Save(Customer customer);
        Maybe<Customer> GetById(int id);
    }
}