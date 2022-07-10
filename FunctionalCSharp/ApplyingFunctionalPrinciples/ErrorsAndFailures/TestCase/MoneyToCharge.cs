using FunctionalCSharp.Functional;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.ErrorsAndFailures.TestCase
{
    public class MoneyToCharge : ValueObject<MoneyToCharge>
    {
        private MoneyToCharge(decimal value)
        {
            Value = value;
        }

        private decimal Value { get; }

        public static Result<MoneyToCharge> Create(decimal moneyToCharge)
        {
            return moneyToCharge is <= 0 or > 1000
                ? Result.Fail<MoneyToCharge>(new MoneyAmountInvalidError())
                : Result.Ok(new MoneyToCharge(moneyToCharge));
        }

        protected override bool EqualsCore(MoneyToCharge other)
        {
            return Value == other.Value;
        }

        protected override int GetHashCodeCore()
        {
            return Value.GetHashCode();
        }

        public static explicit operator MoneyToCharge(decimal moneyToCharge)
        {
            return Create(moneyToCharge).Type;
        }

        public static implicit operator decimal(MoneyToCharge moneyToCharge)
        {
            return moneyToCharge.Value;
        }
    }
}