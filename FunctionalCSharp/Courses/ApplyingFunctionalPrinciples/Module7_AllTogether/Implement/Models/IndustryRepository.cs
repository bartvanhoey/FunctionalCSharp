using FunctionalCSharp.Functional.MaybeClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Models
{
    public class IndustryRepository : Repository<Industry>
    {
        public IndustryRepository(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public Maybe<Industry> GetByName(string name) 
            => UnitOfWork.Query<Industry>().SingleOrDefault(x => x.Name == name);
    }
}
