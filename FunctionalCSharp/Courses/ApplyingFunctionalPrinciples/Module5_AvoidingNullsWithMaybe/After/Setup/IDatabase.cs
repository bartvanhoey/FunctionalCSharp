using Fupr.Functional.MaybeClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module5_AvoidingNullsWithMaybe.After.Setup;

public interface IDatabase
{
    void Save(Customer customer);
    Maybe<Customer?> GetById(int id);
}