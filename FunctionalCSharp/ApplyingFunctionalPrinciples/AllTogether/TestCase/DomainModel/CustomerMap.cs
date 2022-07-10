using FluentNHibernate.Mapping;
using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Model;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel
{
    public class CustomerMap : ClassMap<MyCustomer>
    {
        public CustomerMap()
        {
            Id(x => x.Id);

            Map(x => x.Name);
            Map(x => x.PrimaryMyEmail);
            Map(x => x.SecondaryEmail).Nullable();
            // Map(x => x.EmailCampaign).CustomType<EmailCampaign>();
            Map(x => x.Status).CustomType<CustomerStatus>();

            // References(x => x.Industry);
        }
    }
}
