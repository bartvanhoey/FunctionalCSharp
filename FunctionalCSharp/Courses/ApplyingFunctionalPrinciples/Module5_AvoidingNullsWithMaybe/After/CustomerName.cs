using CSharpFunctionalExtensions;
using static System.String;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module5_AvoidingNullsWithMaybe.After;

public class CustomerName : Shared.ValueObjectClass.ValueObject<CustomerName>
{
    private CustomerName(string value)
    {
        Value = value;
    }

    public string Value { get; }

    public static Result<CustomerName> Create(string customerName)
    {
        if (IsNullOrWhiteSpace(customerName))
            return Result.Failure<CustomerName>("Customer name is required");

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