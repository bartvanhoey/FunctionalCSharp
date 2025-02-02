using CSharpFunctionalExtensions;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After;

public class MoneyToCharge : Shared.ValueObjectClass.ValueObject<MoneyToCharge>
{
    public decimal Value { get; }
    private MoneyToCharge(decimal moneyToCharge) => Value = moneyToCharge;

    public static Result<MoneyToCharge> Create(decimal moneyToCharge) =>
        moneyToCharge is <= 0 or > 1000
            ? Result.Failure<MoneyToCharge>("MoneyToCharge must be between 0 and 1000")
            : new MoneyToCharge(moneyToCharge);

    protected override bool EqualsCore(MoneyToCharge other) => Value == other.Value;

    protected override int GetHashCodeCore() => Value.GetHashCode();
        
    public static explicit operator MoneyToCharge(decimal moneyToCharge) => Create(moneyToCharge).Value;
    public static implicit operator decimal(MoneyToCharge moneyToCharge) => moneyToCharge.Value;
}