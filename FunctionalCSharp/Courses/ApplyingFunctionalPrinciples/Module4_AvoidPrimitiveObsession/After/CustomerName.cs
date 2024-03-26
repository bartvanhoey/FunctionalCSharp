using Fupr;
using Fupr.Functional.ResultClass;
using Fupr.Functional.ValueObjectClass;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After.ResultErrors.Factory.ResultErrorFactory;
using static Fupr.Functional.ResultClass.Result;


namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After;

public class CustomerName : ValueObject<CustomerName>
{
    private string Value { get; }
    private CustomerName(string value) => Value = value;

    public static Result<CustomerName> Create(string customerName)
    {
        if (customerName.IsNullOrWhiteSpace()) return Fail<CustomerName>(CustomerNameEmpty);

        customerName = customerName.Trim();

        return customerName.Length > 100
            ? Fail<CustomerName>(CustomerNameTooLong)
            : Ok(new CustomerName(customerName));
    }

    protected override bool EqualsCore(CustomerName other) => Value == other.Value;

    protected override int GetHashCodeCore() => Value.GetHashCode();

    public static explicit operator CustomerName(string customerName) => Create(customerName).Value;

    public static implicit operator string(CustomerName customerName) => customerName.Value;
}