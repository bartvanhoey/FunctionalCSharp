using FunctionalCSharp.Exceptions.ResultClass;
using FunctionalCSharp.Exceptions.ResultClass.Errors.CustomerName;
using FunctionalCSharp.PrimitiveObsession.ValueObjects.Base;
using static System.String;

namespace FunctionalCSharp.PrimitiveObsession.ValueObjects
{
    public class CustomerName : ValueObject<CustomerName>
    {
        private readonly string _value;
        public string Value => _value;

        private CustomerName(string value) => _value = value;

        public static Result<CustomerName> Create(string customerName)
        {
            if (IsNullOrWhiteSpace(customerName))
                return Result.Fail<CustomerName>(new CustomerNameEmptyError());

            customerName = customerName.Trim();
            return customerName.Length > 100
                ? Result.Fail<CustomerName>(new CustomerNameTooLongError())
                : Result.Ok(new CustomerName(customerName));
        }

        protected override bool EqualsCore(CustomerName other) => _value == other._value;
        protected override int GetHashCodeCore() => _value.GetHashCode();

        public static explicit operator CustomerName(string customerName) => Create(customerName).Type;

        public static implicit operator string(CustomerName customerName) => customerName._value;
    }
}