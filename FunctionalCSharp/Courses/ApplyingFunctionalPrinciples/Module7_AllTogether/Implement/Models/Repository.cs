using FunctionalCSharp.Functional.MaybeClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Models
{
    public class Repository<T> where T : Entity
    {
        protected readonly UnitOfWork UnitOfWork;

        protected Repository(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }

        public  Maybe<T>  GetById(long id)
        {
            return UnitOfWork.Get<T>(id);
        }

        public void Save(T? entity)
        {
            UnitOfWork.SaveOrUpdate(entity);
        }
    }
}
