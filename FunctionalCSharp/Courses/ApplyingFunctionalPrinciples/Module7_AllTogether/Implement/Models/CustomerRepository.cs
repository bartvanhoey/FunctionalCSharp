namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Models
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Customer? GetByName(string name)
        {
            return UnitOfWork.Query<Customer>().SingleOrDefault(x => x.Name == name);
        }
    }
}
