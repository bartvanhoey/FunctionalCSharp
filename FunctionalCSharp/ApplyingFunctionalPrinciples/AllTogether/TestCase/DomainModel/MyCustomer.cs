using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.ValueObjects;
using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Logic;
using FunctionalCSharp.Functional.Maybe;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel
{
    public class MyCustomer : Entity
    {
        public MyCustomerName Name { get; protected set; }
        public MyEmail PrimaryMyEmail { get; protected set; }

        private readonly string _secondaryEmail;
        public Maybe<MyEmail> SecondaryEmail
        {
            get => _secondaryEmail == null ? null : (MyEmail)_secondaryEmail;
            private init { _secondaryEmail = value.Unwrap(x => x.Value); }
        }

        public EmailSettings EmailSettings { get; protected set; }

        public CustomerStatus Status { get; protected set; }
        
        private MyCustomer()
        {
        }

        public MyCustomer(MyCustomerName name, MyEmail primaryEmail,Maybe<MyEmail>  secondaryEmail, Industry industry)
            : this()
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PrimaryMyEmail = primaryEmail ?? throw new ArgumentNullException(nameof(primaryEmail));
            SecondaryEmail = secondaryEmail;
            Status = CustomerStatus.Regular;
            EmailSettings = new EmailSettings(industry, false);
        }



        private EmailCampaign GetEmailCampaign(Industry industry)
        {
            return industry.Name switch
            {
                Industry.CarsIndustry => EmailCampaign.LatestCarModels,
                Industry.PharmacyIndustry => EmailCampaign.PharmacyNews,
                _ => EmailCampaign.Generic
            };
        }

        public void DisableEmailing()
        {
            EmailSettings = EmailSettings.DisableEmailing();
        }

        public void UpdateIndustry(Industry industry)
        {
            EmailSettings = EmailSettings.ChangeIndustry(industry);
        }

        public bool CanBePromoted()
        {
            return Status != CustomerStatus.Gold;
        }

        public void Promote()
        {
            if (!CanBePromoted()) throw new InvalidOperationException();
            Status = Status switch
            {
                CustomerStatus.Regular => CustomerStatus.Preferred,
                CustomerStatus.Preferred => CustomerStatus.Gold,
                CustomerStatus.Gold => throw new InvalidOperationException(),
                _ => throw new InvalidOperationException()
            };
        }
    }
}