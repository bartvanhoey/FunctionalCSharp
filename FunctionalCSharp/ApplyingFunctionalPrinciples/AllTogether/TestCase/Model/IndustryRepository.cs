using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Logic;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Model
{
    public class IndustryRepository : Repository<Industry>
    {
        public IndustryRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Industry GetByName(string name)
        {
            return _unitOfWork.Query<Industry>().SingleOrDefault(x => x.Name == name);
        }
    }
}
