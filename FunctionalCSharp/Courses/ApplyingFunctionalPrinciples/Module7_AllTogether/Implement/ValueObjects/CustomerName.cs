using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.BaseErrors;
using FunctionalCSharp.Functional.MaybeClass;
using FunctionalCSharp.Functional.ResultClass;
using FunctionalCSharp.Functional.ValueObjectClass;
using static FunctionalCSharp.Functional.ResultClass.Result;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.ValueObjects
{
    public class CustomerName : ValueObject<CustomerName>
    {
        public string Value { get; }

        private CustomerName(string value) => Value = value;


        public static Result<CustomerName> CreateCustomerName(Maybe<string> maybeCustomerName) =>
            maybeCustomerName.ToResult(new CustomerNameShouldNotBeEmptyError())
                .OnSuccess(n => n.Trim())
                .Ensure(n => n.Length > 2, new CustomerNameShouldBeAtLeastTwoCharactersError())
                .Ensure(n => n.Length < 100, new CustomerNameShouldBeLessThan100CharactersError())
                .Map(n => new CustomerName(n));

        protected override bool EqualsCore(CustomerName other) => Value == other.Value;
        protected override int GetHashCodeCore() => Value.GetHashCode();

        public static implicit operator string(CustomerName customerName) => customerName.Value;

        public static explicit operator CustomerName(string customerName) => CreateCustomerName(customerName).Type;
    }
}