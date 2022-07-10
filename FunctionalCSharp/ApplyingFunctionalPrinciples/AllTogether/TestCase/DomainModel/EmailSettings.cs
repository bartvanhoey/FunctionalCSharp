using FunctionalCSharp.Functional;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel
{
    public class EmailSettings : ValueObject<EmailSettings>
    {
        private EmailSettings()
        {
        }


        public EmailSettings(Industry industry, bool emailingIsDisabled)
        {
            Industry = industry;
            EmailingIsDisabled = emailingIsDisabled;
        }

        public Industry Industry { get; }
        public bool EmailingIsDisabled { get; }
        public EmailCampaign EmailCampaign => GetEmailCampaign(Industry);

        private EmailCampaign GetEmailCampaign(Industry industry)
        {
            if (EmailingIsDisabled) return EmailCampaign.None;

            return industry.Name switch
            {
                Industry.CarsIndustry => EmailCampaign.LatestCarModels,
                Industry.PharmacyIndustry => EmailCampaign.PharmacyNews,
                Industry.OtherIndustry => EmailCampaign.Generic,
                _ => throw new ArgumentException()
            };
        }

        public EmailSettings DisableEmailing()
        {
            return new(Industry, false);
        }

        public EmailSettings ChangeIndustry(Industry industry)
        {
            return new(industry, EmailingIsDisabled);
        }

        protected override bool EqualsCore(EmailSettings other)
        {
            return Industry == other.Industry && EmailingIsDisabled == other.EmailingIsDisabled;
        }

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}