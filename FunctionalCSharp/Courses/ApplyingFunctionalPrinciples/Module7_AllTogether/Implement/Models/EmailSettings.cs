using FunctionalCSharp.Functional.ValueObjectClass;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Models.EmailCampaign;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Models.Industry;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Models
{
    public class EmailSettings : ValueObject<EmailSettings>
    {
        public  Industry Industry { get; }
        public  bool EmailingIsDisabled { get; }
        
        public EmailCampaign EmailCampaign => GetEmailCampaign(Industry);

        private EmailCampaign GetEmailCampaign(Industry industry)
        {
            if (EmailingIsDisabled) return None;
            if (industry == Cars) return LatestCarModels;
            if (industry == Pharmacy) return PharmacyNews;
            if (industry == Other) return Generic;
            throw new ArgumentException();
        }

        public EmailSettings(Industry industry, bool emailingIsDisabled)
        {
            Industry = industry ?? throw new ArgumentNullException(nameof(industry));
            EmailingIsDisabled = emailingIsDisabled;
        }
        
        public EmailSettings DisableEmailing() => new(Industry, true);
        public EmailSettings ChangeIndustry(Industry industry) => new(industry, EmailingIsDisabled);

        protected override bool EqualsCore(EmailSettings other) 
            => Industry == other.Industry && EmailingIsDisabled == other.EmailingIsDisabled;

        protected override int GetHashCodeCore()
        {
            unchecked
            {
                var hashCode = Industry.GetHashCode();
                hashCode = (hashCode * 397) ^ EmailingIsDisabled.GetHashCode();
                return hashCode;
            }
        }
    }
}