using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.After.Errors.CustomerName;
using FunctionalCSharp.Functional.ResultClass;
using FunctionalCSharp.Functional.ValueObjectClass;
using static System.String;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module5_AvoidingNullsWithMaybeType.After
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
            if (IsNullOrWhiteSpace(customerName))
                return Result.Fail<CustomerName>(new CustomerNameEmptyResultError());

            customerName = customerName.Trim();
            return customerName.Length > 100
                ? Result.Fail<CustomerName>(new CustomerNameTooLongResultError())
                : Result.Ok(new CustomerName(customerName));
        }

        protected override bool EqualsCore(CustomerName other) => Value == other.Value;

        protected override int GetHashCodeCore() => Value.GetHashCode();

        public static explicit operator CustomerName(string customerName) => Create(customerName).Value;

        public static implicit operator string(CustomerName customerName) => customerName.Value;
    }
}