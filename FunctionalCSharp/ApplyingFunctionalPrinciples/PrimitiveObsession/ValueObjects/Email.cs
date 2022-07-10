using FunctionalCSharp.ApplyingFunctionalPrinciples.Exceptions.Errors.Email;
using FunctionalCSharp.Functional;
using static System.String;
using static System.Text.RegularExpressions.Regex;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.PrimitiveObsession.ValueObjects
{
    public class Email : ValueObject<Email>
    {
        private readonly string _value;
        private Email(string value) => _value = value;
        
        public string Value => _value;
    
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

       

        protected override bool EqualsCore(Email other) => _value == other._value;
        protected override int GetHashCodeCore() => _value.GetHashCode();

        public static explicit operator Email(string email) => Create(email).Type;
        public static implicit operator string (Email email) => email._value;
    }
}