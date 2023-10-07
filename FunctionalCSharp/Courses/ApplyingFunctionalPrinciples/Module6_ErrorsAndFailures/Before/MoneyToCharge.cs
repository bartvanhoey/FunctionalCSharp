using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.After;
using FunctionalCSharp.Functional.ResultClass;
using FunctionalCSharp.Functional.ValueObjectClass;
using static FunctionalCSharp.Functional.ResultClass.Result;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.Before
{
    public class MoneyToCharge : ValueObject<MoneyToCharge>
    {
        public decimal Value { get;  }
        private MoneyToCharge(decimal value) => Value = value;
        public static Result<MoneyToCharge> CreateMoneyToCharge(decimal moneyAmount) =>
            moneyAmount is <= 0 or > 100 
                ? Fail<MoneyToCharge>(new MoneyAmountInvalidResultError()) 
                : Ok(new MoneyToCharge(moneyAmount));

        protected override bool EqualsCore(MoneyToCharge other) 
            => Value == other.Value;
        protected override int GetHashCodeCore() 
            => Value.GetHashCode();
        
        public static implicit operator decimal(MoneyToCharge moneyToCharge) 
            => moneyToCharge.Value;

        public static explicit operator MoneyToCharge(decimal moneyToCharge) 
            => CreateMoneyToCharge(moneyToCharge).Value;
    }
}