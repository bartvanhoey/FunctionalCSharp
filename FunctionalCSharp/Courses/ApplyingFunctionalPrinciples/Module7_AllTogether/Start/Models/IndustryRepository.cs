namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Start.Models
{
    public class IndustryRepository : Repository<Industry>
    {
        public IndustryRepository(UnitOfWork unitOfWork)
            : base(unitOfWork)
        {
        }

        public Industry GetByName(string name)
        {
            return _unitOfWork.Query<Industry>()
                .SingleOrDefault(x => x.Name == name);
        }
    }
}
