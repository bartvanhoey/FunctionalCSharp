using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel;
using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Logic;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Model
{
    public class CustomerRepository : Repository<MyCustomer>
    {
        public CustomerRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public MyCustomer GetByName(string name)
        {
            return _unitOfWork.Query<MyCustomer>().SingleOrDefault(x => x.Name == name);
        }
    }
}
