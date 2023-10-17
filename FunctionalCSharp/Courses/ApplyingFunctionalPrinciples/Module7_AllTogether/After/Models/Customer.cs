using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.ValueObjects;
using Fupr.Functional.MaybeClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.Models
{
    public class Customer : Entity
    {
        public virtual CustomerName Name { get; protected set; }
        public virtual Email PrimaryEmail { get; protected set; }

        private readonly string? _secondaryEmail;
        public virtual Email? SecondaryEmail
        {
            get => (_secondaryEmail == null ? null : (Email)_secondaryEmail)!;
            protected init => _secondaryEmail = value?.Value;
        }

        public virtual EmailSettings EmailSettings { get; protected set; }
        public virtual CustomerStatus Status { get; protected set; }

        protected Customer()
        {
        }

        public Customer(CustomerName name, Email primaryEmail, Maybe<Email?> secondaryEmail, Industry industry)
            : this()
        {
            Name = name ?? throw new ArgumentNullException(nameof(name));
            PrimaryEmail = primaryEmail ?? throw new ArgumentNullException(nameof(primaryEmail));
            SecondaryEmail = secondaryEmail.HasValue ? secondaryEmail.Value : null;
            EmailSettings = new EmailSettings(industry, false);
            Status = CustomerStatus.Regular;
        }



        public virtual void DisableEmailing()
            => EmailSettings = EmailSettings.DisableEmailing();

        public virtual void UpdateIndustry(Industry industry)
            => EmailSettings = EmailSettings.UpdateIndustry(industry);

        public virtual bool CanBePromoted() => Status != CustomerStatus.Gold;

        public virtual void Promote()
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