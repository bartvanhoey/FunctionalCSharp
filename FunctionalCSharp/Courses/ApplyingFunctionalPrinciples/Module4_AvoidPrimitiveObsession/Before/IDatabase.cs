using FunctionalCSharp.Functional.MaybeClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.Before
{
    public interface IDatabase
    {
        void Save(Customer customer);
    }
}