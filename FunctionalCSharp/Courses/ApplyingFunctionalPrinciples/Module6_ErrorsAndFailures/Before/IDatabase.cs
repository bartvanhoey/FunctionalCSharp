namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.Before
{
    public interface IDatabase
    {
        Customer? GetById(int customerId);
        void Save(Customer customer);
    }
}