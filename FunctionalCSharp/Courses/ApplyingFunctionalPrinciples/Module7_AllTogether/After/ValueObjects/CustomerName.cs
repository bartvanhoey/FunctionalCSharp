using CSharpFunctionalExtensions;


namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.ValueObjects;

public class CustomerName : Shared.ValueObjectClass.ValueObject<CustomerName>
{
    public string Value { get; }

    private CustomerName(string value) => Value = value;

    public static Result<CustomerName> Create(Maybe<string?> customerName)
    {
        var result = customerName.ToResult("Customer name cannot be empty")
            .Tap(name => name?.Trim())
            .Ensure(name => name != string.Empty, "Customer name cannot be empty")
            .Ensure(name => name is { Length: <= 200 }, "Customer name cannot be longer than 200 characters")
            .Finally(name => name.IsSuccess ? new CustomerName(name.Value) : Result.Failure<CustomerName>("Customer name cannot be empty"));
        
        return result.Value;
    }

    protected override bool EqualsCore(CustomerName other) => Value == other.Value;
    protected override int GetHashCodeCore() => Value.GetHashCode();
    public static explicit operator CustomerName(string customerName) => Create(customerName!).Value;
    public static implicit operator string(CustomerName customerName) => customerName.Value;
}