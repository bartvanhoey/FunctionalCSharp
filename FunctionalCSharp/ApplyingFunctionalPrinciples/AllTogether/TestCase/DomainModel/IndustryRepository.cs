using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Logic;
using FunctionalCSharp.Functional.MaybeType;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel
{
    public class IndustryRepository : Repository<Industry>
    {
        public IndustryRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Maybe<Industry> GetByName(string name)
        {
            return _unitOfWork.Query<Industry>().SingleOrDefault(x => x.Name == name);
        }
    }
}