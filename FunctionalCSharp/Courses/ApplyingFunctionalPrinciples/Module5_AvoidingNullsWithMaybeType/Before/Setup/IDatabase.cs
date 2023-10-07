using FunctionalCSharp.Functional.MaybeClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module5_AvoidingNullsWithMaybeType.Before.Setup
{
    public interface IDatabase
    {
        void Save(Customer customer);
        Customer? GetById(int id);
    }
}