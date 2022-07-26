using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.Logic;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel
{
    public class CustomerRepository : Repository<MyCustomer>
    {
        public CustomerRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public MyCustomer? GetByName(string name) => _unitOfWork.Query<MyCustomer>().SingleOrDefault(x => x.Name == name);
    }
}