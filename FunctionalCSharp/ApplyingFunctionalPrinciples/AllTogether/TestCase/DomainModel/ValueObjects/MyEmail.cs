using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors;
using FunctionalCSharp.Functional;
using static System.String;
using static System.Text.RegularExpressions.Regex;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.ValueObjects
{
    public class MyEmail : ValueObject<MyEmail>
    {
        private readonly string _value;
        private MyEmail(string value) => _value = value;
        
        public string Value => _value;
        public static Result<MyEmail> Create(string myEmail)
        {
            if (IsNullOrWhiteSpace(myEmail))
                return Result.Fail<MyEmail>(new MyEmailEmptyError());

            myEmail = myEmail.Trim();
            if (myEmail.Length > 256) return Result.Fail<MyEmail>(new MyEmailTooLongError());

            return IsMatch(myEmail, @"^(.+)@(.+)$")
                ? Result.Ok(new MyEmail(myEmail))
                : Result.Fail<MyEmail>(new MyEmailInvalidError());
        }
        protected override bool EqualsCore(MyEmail other) => _value == other._value;
        protected override int GetHashCodeCore() => _value.GetHashCode();
        public static explicit operator MyEmail(string myEmail) => Create(myEmail).Type;
        public static implicit operator string (MyEmail myEmail) => myEmail._value;
    }
}