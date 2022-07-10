using FunctionalCSharp.ApplyingFunctionalPrinciples.Exceptions.Errors.Email;
using FunctionalCSharp.Functional;
using static System.String;
using static System.Text.RegularExpressions.Regex;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.PrimitiveObsession.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        private Email(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<Email> Create(string email)
        {
            if (IsNullOrWhiteSpace(email))
                return Result.Fail<Email>(new EmailEmptyError());

            email = email.Trim();
            if (email.Length > 256) return Result.Fail<Email>(new EmailTooLongError());

            return IsMatch(email, @"^(.+)@(.+)$")
                ? Result.Ok(new Email(email))
                : Result.Fail<Email>(new EmailInvalidError());
        }


        protected override bool EqualsCore(Email other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static explicit operator Email(string email)
        {
            return Create(email).Type;
        }

        public static implicit operator string(Email email)
        {
            return email.Value;
        }
    }
}