namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Logic
{
    public class Repository<T>
        where T : Entity
    {
        protected readonly UnitOfWork _unitOfWork;

        protected Repository(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public T? GetById(long id)
        {
            return _unitOfWork.Get<T>(id);
        }

        public void Save(T entity)
        {
            _unitOfWork.SaveOrUpdate(entity);
        }
    }

    public class UnitOfWork
    {
        public void SaveOrUpdate<T>(T entity) where T : Entity
        {
            
            
        }

        public T Get<T>(long id) where T : Entity
        {
            
            return  default;
        }

        public IEnumerable<T> Query<T>()
        {
            throw new NotImplementedException();
        }

        public void Commit()
        {
            throw new NotImplementedException();
        }
    }
}
