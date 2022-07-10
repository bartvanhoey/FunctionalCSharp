using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Model;
using FunctionalCSharp.Functional;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel
{
    public class EmailSettings : ValueObject<EmailSettings>
    {
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

        private EmailSettings()
        {
        }


        public EmailSettings(Industry industry, bool emailingIsDisabled)
        {
            Industry = industry;
            EmailingIsDisabled = emailingIsDisabled;
        }

        public EmailSettings DisableEmailing() => new EmailSettings(Industry, false);
        public EmailSettings ChangeIndustry(Industry industry) => new EmailSettings(industry, EmailingIsDisabled);

        protected override bool EqualsCore(EmailSettings other) =>
            Industry == other.Industry && EmailingIsDisabled == other.EmailingIsDisabled;

        protected override int GetHashCodeCore()
        {
            throw new NotImplementedException();
        }
    }
}