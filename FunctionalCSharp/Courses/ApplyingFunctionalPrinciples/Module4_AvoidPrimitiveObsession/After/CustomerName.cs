using CSharpFunctionalExtensions;
using FunctionalCSharp.Shared.Extensions;


namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After;

public class CustomerName : Shared.ValueObjectClass.ValueObject<CustomerName>
{
    private string Value { get; }
    private CustomerName(string value) => Value = value;

    public static Result<CustomerName> Create(string customerName)
    {
        if (customerName.IsNullOrWhiteSpace()) return Result.Failure<CustomerName>("Customer name is required");

        customerName = customerName.Trim();

        return customerName.Length > 100
            ? Result.Failure<CustomerName>("Customer name is too long")
            : new CustomerName(customerName);
    }

    protected override bool EqualsCore(CustomerName other) => Value == other.Value;

    protected override int GetHashCodeCore() => Value.GetHashCode();

    public static explicit operator CustomerName(string customerName) => Create(customerName).Value;

    public static implicit operator string(CustomerName customerName) => customerName.Value;
}