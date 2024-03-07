using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After.ResultErrors.Factory;
using Fupr.Extensions;
using Fupr.Functional.ResultClass;
using Fupr.Functional.ValueObjectClass;
using static Fupr.Functional.ResultClass.Result;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module5_AvoidingNullsWithMaybe.Before
{
    public class CustomerName : ValueObject<CustomerName>
    {
        private CustomerName(string value)
        {
            Value = value;
        }

        public string Value { get; }

        public static Result<CustomerName> Create(string customerName)
        {
            if (customerName.IsNullOrWhiteSpace())
                return Fail<CustomerName>(ResultErrorFactory.CustomerNameEmpty);

            customerName = customerName.Trim();
            return customerName.Length > 100
                ? Fail<CustomerName>( ResultErrorFactory.CustomerNameTooLong)
                : Ok(new CustomerName(customerName));
        }

        protected override bool EqualsCore(CustomerName other) => Value == other.Value;

        protected override int GetHashCodeCore() => Value.GetHashCode();

        public static explicit operator CustomerName(string customerName) => Create(customerName).Value;

        public static implicit operator string(CustomerName customerName) => customerName.Value;
    }
}