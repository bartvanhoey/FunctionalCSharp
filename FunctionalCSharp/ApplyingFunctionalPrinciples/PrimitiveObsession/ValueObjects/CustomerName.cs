using FunctionalCSharp.ApplyingFunctionalPrinciples.Exceptions.Errors.CustomerName;
using FunctionalCSharp.Functional;
using FunctionalCSharp.Functional.PrimitiveObsession;
using FunctionalCSharp.Functional.ResultType;
using static System.String;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.PrimitiveObsession.ValueObjects
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
                return Result.Fail<CustomerName>(new CustomerNameEmptyError());

            customerName = customerName.Trim();
            return customerName.Length > 100
                ? Result.Fail<CustomerName>(new CustomerNameTooLongError())
                : Result.Ok(new CustomerName(customerName));
        }

        protected override bool EqualsCore(CustomerName other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static explicit operator CustomerName(string customerName)
        {
            return Create(customerName).Type;
        }

        public static implicit operator string(CustomerName customerName)
        {
            return customerName.Value;
        }
    }
}