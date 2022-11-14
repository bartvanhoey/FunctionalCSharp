namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Start.Models
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Customer GetByName(string name)
        {
            return _unitOfWork.Query<Customer>()
                .SingleOrDefault(x => x.Name == name);
        }
    }
}
