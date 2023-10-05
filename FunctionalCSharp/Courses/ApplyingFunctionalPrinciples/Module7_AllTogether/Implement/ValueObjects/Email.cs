using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.Email;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors;
using FunctionalCSharp.Extensions;
using FunctionalCSharp.Functional.MaybeClass;
using FunctionalCSharp.Functional.ResultClass;
using FunctionalCSharp.Functional.ValueObjectClass;


namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        public string Value { get; }
        private Email(string email) => Value = email;
        public static Result<Email> CreateEmail(Maybe<string> maybeEmail) =>
            maybeEmail
                .ToResult(new EmailShouldNotBeNullOrWhiteSpaceResultError())
                .OnSuccess(email => email.Trim())
                .Ensure(email => email.Length > 0, new EmailShouldNotBeEmptyResultError())
                .Ensure(email => email.Length < 256, new EmailShouldNotBeLongerThen256Characters())
                .Ensure(email => email.IsValidEmailAddress(), new EmailInvalidResultError())
                .Map(email => new Email(email));

        protected override bool EqualsCore(Email other) => Value == other.Value;
        protected override int GetHashCodeCore() => Value.GetHashCode();
        
        public static implicit operator string(Email? email) => email.Value;
        public static explicit operator Email(string email) => CreateEmail(email).Type; 
    }
}