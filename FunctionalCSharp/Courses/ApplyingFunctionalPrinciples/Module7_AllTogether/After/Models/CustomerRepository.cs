namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.Models;

public class CustomerRepository : Repository<Customer>
{
    public CustomerRepository(UnitOfWork unitOfWork)
        : base(unitOfWork)
    {
    }

    public Customer GetByName(string name)
    {
        return Uow.Query<Customer>()
            .SingleOrDefault(x => x.Name == name);
    }
}