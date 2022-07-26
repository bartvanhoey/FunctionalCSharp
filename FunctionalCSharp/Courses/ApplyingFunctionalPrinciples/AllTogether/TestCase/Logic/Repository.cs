using FunctionalCSharp.Functional.MaybeType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.Logic
{
    public class Repository<T>
        where T : Entity
    {
        protected readonly UnitOfWork _unitOfWork;

        protected Repository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public Maybe<T>  GetById(long id) => _unitOfWork.Get<T>(id);

        public void Save(T entity)
        {
            _unitOfWork.SaveOrUpdate(entity);
        }
    }
}