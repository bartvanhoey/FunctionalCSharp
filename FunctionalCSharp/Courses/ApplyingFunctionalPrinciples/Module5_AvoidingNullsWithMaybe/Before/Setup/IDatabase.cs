namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module5_AvoidingNullsWithMaybe.Before.Setup
{
    public interface IDatabase
    {
        void Save(Customer customer);
        Customer? GetById(int id);
    }
}