using FunctionalCSharp.Exceptions.ResultClass;
using FunctionalCSharp.PrimitiveObsession.ValueObjects.Base;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.ErrorsAndFailures.TestCase
{
    public class MoneyToCharge : ValueObject<MoneyToCharge>
    {
        private decimal Value { get; }
        private MoneyToCharge(decimal value) => Value = value;

        public static Result<MoneyToCharge> Create(decimal moneyToCharge) =>
            moneyToCharge is <= 0 or > 1000 
                ? Result.Fail<MoneyToCharge>(new MoneyAmountInvalidError()) 
                : Result.Ok(new MoneyToCharge(moneyToCharge));

        protected override bool EqualsCore(MoneyToCharge other) => Value == other.Value;
        protected override int GetHashCodeCore() => Value.GetHashCode();

        public static explicit operator MoneyToCharge(decimal moneyToCharge) => Create(moneyToCharge).Type;

        public static implicit operator decimal (MoneyToCharge moneyToCharge) => moneyToCharge.Value;
    }
}