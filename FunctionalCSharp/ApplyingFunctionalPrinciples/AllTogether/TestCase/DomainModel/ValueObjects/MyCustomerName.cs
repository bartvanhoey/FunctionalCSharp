using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors;
using FunctionalCSharp.Functional;
using static System.String;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.ValueObjects
{
    public class MyCustomerName : ValueObject<MyCustomerName>
    {
        private readonly string _value;
        public string Value => _value;
        private MyCustomerName(string value) => _value = value;
        public static Result<MyCustomerName> Create(string myCustomerName)
        {
            if (IsNullOrWhiteSpace(myCustomerName)) return Result.Fail<MyCustomerName>(new MyCustomerNameEmptyError());

            myCustomerName = myCustomerName.Trim();
            return myCustomerName.Length > 100
                ? Result.Fail<MyCustomerName>(new MyCustomerNameTooLongError())
                : Result.Ok(new MyCustomerName(myCustomerName));
        }

        protected override bool EqualsCore(MyCustomerName other) => _value == other._value;
        protected override int GetHashCodeCore() => _value.GetHashCode();
        public static explicit operator MyCustomerName(string myCustomerName) => Create(myCustomerName).Type;
        public static implicit operator string(MyCustomerName myCustomerName) => myCustomerName._value;
    }
}