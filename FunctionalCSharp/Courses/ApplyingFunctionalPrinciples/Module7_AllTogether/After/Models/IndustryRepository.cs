using Fupr.Functional.MaybeClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.Models;

public class IndustryRepository : Repository<Industry>
{
    public IndustryRepository(UnitOfWork uow)
        : base(uow)
    {
    }

    public Maybe<Industry> GetByName(string name)
    {
        return Uow.Query<Industry>()
            .SingleOrDefault(x => x.Name == name);
    }
}