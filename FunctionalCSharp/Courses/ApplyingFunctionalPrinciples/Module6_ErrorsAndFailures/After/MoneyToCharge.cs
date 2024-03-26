using Fupr.Functional.ResultClass;
using Fupr.Functional.ValueObjectClass;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After.ResultErrors.Factory.ResultErrorFactory;
using static Fupr.Functional.ResultClass.Result;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After;

public class MoneyToCharge : ValueObject<MoneyToCharge>
{
    public decimal Value { get; }
    private MoneyToCharge(decimal moneyToCharge) => Value = moneyToCharge;

    public static Result<MoneyToCharge> Create(decimal moneyToCharge) =>
        moneyToCharge is <= 0 or > 1000
            ? Fail<MoneyToCharge>(MoneyAmountIsInvalid)
            : Ok(new MoneyToCharge(moneyToCharge));

    protected override bool EqualsCore(MoneyToCharge other) => Value == other.Value;

    protected override int GetHashCodeCore() => Value.GetHashCode();
        
    public static explicit operator MoneyToCharge(decimal moneyToCharge) => Create(moneyToCharge).Value;
    public static implicit operator decimal(MoneyToCharge moneyToCharge) => moneyToCharge.Value;
}