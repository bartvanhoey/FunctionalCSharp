using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.ValueObjects;
using FunctionalCSharp.Functional.MaybeClass;
using JetBrains.Annotations;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Models.CustomerStatus;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Models
{
    public class Customer : Entity
    {
        public string Name { get; }
        
        private readonly string _primaryEmail; 
        public Email PrimaryEmail  => (Email) _primaryEmail;

        private readonly string? _secondaryEmail;
        public Maybe<Email> SecondaryEmail
        {
            get => _secondaryEmail == null ? null : (Email) _secondaryEmail;
            private init { _secondaryEmail = value.Unwrap(x => x.Value); }
        }

        public EmailSettings EmailSettings { get; private set; }
        public CustomerStatus Status { get; private set; }

        public Customer(CustomerName name, Email primaryEmail, Maybe<Email> secondaryEmail, Industry industry)
        {
            Name = name ?? throw new ArgumentNullException(nameof(name)); 
            _primaryEmail = primaryEmail ?? throw new ArgumentNullException(nameof(primaryEmail));
            SecondaryEmail = secondaryEmail;
            EmailSettings = new EmailSettings(industry, false);
            Status = Regular;
        }

        public virtual void DisableEmailing() 
            => EmailSettings = EmailSettings.DisableEmailing();

        public virtual void UpdateIndustry(Industry industry) 
            => EmailSettings = EmailSettings.ChangeIndustry(industry);

        public virtual bool CanBePromoted() => Status != Gold;
        public virtual void Promote()
        {
            if (!CanBePromoted()) throw new InvalidOperationException();
            Status = Status switch
            {
                Regular => Preferred,
                Preferred => Gold,
                Gold => throw new InvalidOperationException(),
                _ => throw new InvalidOperationException()
            };
        }
    }
}