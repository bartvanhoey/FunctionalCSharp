using System.Linq;
using CustomerManagement.Logic.Common;
using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.Logic;

namespace CustomerManagement.Logic.Model
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
