using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.Errors;
using FunctionalCSharp.Functional;
using FunctionalCSharp.Functional.Maybe;
using static System.String;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel.ValueObjects
{
    public class MyCustomerName : ValueObject<MyCustomerName>
    {
        private MyCustomerName(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<MyCustomerName> Create(Maybe<string> customerNameOrNothing)
        {
            if (customerNameOrNothing.HasNoValue) 
                return Result.Fail<MyCustomerName>(new MyCustomerNameEmptyError());

            var myCustomerName = customerNameOrNothing.Type.Trim();
            return myCustomerName.Length > 100
                ? Result.Fail<MyCustomerName>(new MyCustomerNameTooLongError())
                : Result.Ok(new MyCustomerName(myCustomerName));
        }

        protected override bool EqualsCore(MyCustomerName other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static explicit operator MyCustomerName(string myCustomerName)
        {
            return Create(myCustomerName).Type;
        }

        public static implicit operator string(MyCustomerName myCustomerName)
        {
            return myCustomerName.Value;
        }
    }
}