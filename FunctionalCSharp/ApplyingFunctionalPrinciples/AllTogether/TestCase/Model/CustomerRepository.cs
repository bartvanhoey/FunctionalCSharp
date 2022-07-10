using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Logic;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Model
{
    public class CustomerRepository : Repository<Customer>
    {
        public CustomerRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Customer GetByName(string name)
        {
            return _unitOfWork.Query<Customer>().SingleOrDefault(x => x.Name == name);
        }
    }
}
