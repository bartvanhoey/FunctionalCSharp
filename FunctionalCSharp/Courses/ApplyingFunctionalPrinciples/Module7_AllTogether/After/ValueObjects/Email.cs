using Fupr.Extensions;
using Fupr.Functional.MaybeClass;
using Fupr.Functional.MaybeClass.Extensions;
using Fupr.Functional.ResultClass;
using Fupr.Functional.ResultClass.Extensions;
using Fupr.Functional.ValueObjectClass;
using static System.String;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.ResultErrors.Factory.ErrorFactory;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        public string Value { get; }

        private Email(string value) => Value = value;

        public static Result<Email> CreateEmail(Maybe<string?> maybeEmail) =>
            maybeEmail.ToResult(EmailEmpty)
                .Tap(email => email!.Trim())
                .Ensure(email => email != Empty, EmailEmpty)
                .Ensure(email => email.Length <= 256, EmailTooLong)
                .Ensure(email => email.IsValidEmailAddress(), EmailTooLong)
                .Map(result =>  new Email(result));

        protected override bool EqualsCore(Email other) => Value == other.Value;
        protected override int GetHashCodeCore() => Value.GetHashCode();
        public static explicit operator Email(string email) => CreateEmail(email!).Value;

        public static implicit operator string(Email email) => email.Value;
    }
}