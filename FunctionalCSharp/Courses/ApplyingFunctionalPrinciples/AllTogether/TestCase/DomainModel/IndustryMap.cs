using FluentNHibernate.Mapping;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel
{
    public class IndustryMap : ClassMap<Industry>
    {
        public IndustryMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);
        }
    }
}