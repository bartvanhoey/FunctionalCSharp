

using CSharpFunctionalExtensions;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.Models;

public class Repository<T>
    where T : Entity
{
    protected readonly UnitOfWork Uow;

    protected Repository(UnitOfWork uow) => Uow = uow;

    public Maybe<T>  GetById(long id)
    {
        return Uow.Get<T>(id);
    }

    public void Save(T entity)
    {
        Uow.SaveOrUpdate(entity);
    }
}