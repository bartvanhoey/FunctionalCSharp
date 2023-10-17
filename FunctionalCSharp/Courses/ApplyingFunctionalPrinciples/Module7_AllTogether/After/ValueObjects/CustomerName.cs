using Fupr.Functional.MaybeClass;
using Fupr.Functional.MaybeClass.Extensions;
using Fupr.Functional.ResultClass;
using Fupr.Functional.ResultClass.Extensions;
using Fupr.Functional.ValueObjectClass;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.ResultErrors.Factory.ErrorFactory;


namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.ValueObjects
{
    public class CustomerName : ValueObject<CustomerName>
    {
        public string Value { get; }

        private CustomerName(string value) => Value = value;

        public static Result<CustomerName> Create(Maybe<string?> customerName) =>
            customerName.ToResult(CustomerNameIsEmpty)
                .Tap(name => name!.Trim())
                .Ensure(name => name != string.Empty, CustomerNameIsEmpty)
                .Ensure(name => name.Length <= 200, CustomerNameIsTooLong)
                .Map(name => new CustomerName(name));

        protected override bool EqualsCore(CustomerName other) => Value == other.Value;
        protected override int GetHashCodeCore() => Value.GetHashCode();
        
        public static explicit operator CustomerName(string customerName) => Create(customerName!).Value;
        public static implicit operator string(CustomerName customerName) => customerName.Value;
    }
}