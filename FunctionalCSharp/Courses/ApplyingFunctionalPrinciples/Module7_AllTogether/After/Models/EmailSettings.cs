using Fupr.Functional.ValueObjectClass;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.Models.Industry;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.Models;

public class EmailSettings : ValueObject<EmailSettings>
{
    public Industry Industry { get; }
    public bool EmailingIsDisabled { get; }

    public EmailCampaign EmailCampaign => GetEmailCampaign(Industry);

    private EmailCampaign GetEmailCampaign(Industry industry)
    {
        if (EmailingIsDisabled) return EmailCampaign.None;
        if (industry == CarsIndustry) return EmailCampaign.LatestCarModels;
        if (industry == PharmaIndustry) return EmailCampaign.PharmacyNews;
        if (industry == OtherIndustry) return EmailCampaign.Generic;
        throw new ArgumentException();
    }

    public EmailSettings DisableEmailing() => new(Industry, true);
    public EmailSettings UpdateIndustry(Industry industry) => new EmailSettings(industry, EmailingIsDisabled);

    public EmailSettings(Industry industry, bool emailingIsDisabled)
    {
        Industry = industry;
        EmailingIsDisabled = emailingIsDisabled;
    }

    protected override bool EqualsCore(EmailSettings other) =>
        Industry == other.Industry && EmailingIsDisabled == other.EmailingIsDisabled;

    protected override int GetHashCodeCore()
    {
        var hashCode = Industry.GetHashCode();
        hashCode = (hashCode * 397) ^ EmailingIsDisabled.GetHashCode();
        return hashCode;
    }
}