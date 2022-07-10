using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.ValueObjects;
using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Logic;
using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Model;
using MyEmail = FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.ValueObjects.MyEmail;


namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel
{
    public class MyCustomer : Entity
    {
        public virtual MyCustomerName Name { get; protected set; }
        public virtual MyEmail PrimaryMyEmail { get; protected set; }
        public virtual MyEmail SecondaryEmail { get; protected set; }
        public virtual Industry Industry { get; protected set; }
        public virtual EmailCampaign EmailCampaign { get; protected set; }
        public virtual CustomerStatus Status { get; protected set; }

        protected MyCustomer()
        {
        }

        public MyCustomer(MyCustomerName name, MyEmail primaryEmail, MyEmail secondaryEmail, Industry industry)
            : this()
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PrimaryMyEmail = primaryEmail ?? throw new ArgumentNullException(nameof(primaryEmail));
            SecondaryEmail = secondaryEmail;
            Industry = industry ?? throw new ArgumentNullException(nameof(industry));
            EmailCampaign = GetEmailCampaign(industry);
            Status = CustomerStatus.Regular;
        }

        private EmailCampaign GetEmailCampaign(Industry industry)
        {
            if (industry.Name == Industry.CarsIndustry)
                return EmailCampaign.LatestCarModels;

            if (industry.Name == Industry.PharmacyIndustry)
                return EmailCampaign.PharmacyNews;

            return EmailCampaign.Generic;
        }

        public virtual void DisableEmailing()
        {
            EmailCampaign = EmailCampaign.None;
        }

        public virtual void UpdateIndustry(Industry industry)
        {
            if (EmailCampaign == EmailCampaign.None)
                return;

            EmailCampaign = GetEmailCampaign(industry);
            Industry = industry;
        }

        public virtual bool CanBePromoted()
        {
            return Status != CustomerStatus.Gold;
        }

        public virtual void Promote()
        {
            if (Status == CustomerStatus.Regular)
            {
                Status = CustomerStatus.Preferred;
            }
            else
            {
                Status = CustomerStatus.Gold;
            }
        }
    }
}
