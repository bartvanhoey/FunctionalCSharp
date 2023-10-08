using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After.Errors;
using FunctionalCSharp.Functional.ResultClass;
using FunctionalCSharp.Functional.ValueObjectClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After
{
    public class MoneyToCharge : ValueObject<MoneyToCharge>
    {
        public decimal Value { get; }
        private MoneyToCharge(decimal moneyToCharge) => Value = moneyToCharge;

        public static Result<MoneyToCharge> Create(decimal moneyToCharge) =>
            moneyToCharge is <= 0 or > 1000
                ? Result.Fail<MoneyToCharge>(new MoneyAmountIsInvalidResultError())
                : Result.Ok(new MoneyToCharge(moneyToCharge));

        protected override bool EqualsCore(MoneyToCharge other) => Value == other.Value;

        protected override int GetHashCodeCore() => Value.GetHashCode();
        
        public static explicit operator MoneyToCharge(decimal moneyToCharge) => Create(moneyToCharge).Value;
        public static implicit operator decimal(MoneyToCharge moneyToCharge) => moneyToCharge.Value;
    }
}