namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.Logic
{
    public abstract class UnitOfWork
    {
        public void SaveOrUpdate<T>(T entity) where T : Entity
        {
        }

        public T Get<T>(long id) where T : Entity
        {
            return default;
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