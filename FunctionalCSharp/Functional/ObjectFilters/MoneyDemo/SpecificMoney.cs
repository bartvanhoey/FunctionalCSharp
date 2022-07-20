namespace FunctionalCSharp.Functional.ObjectFilters.MoneyDemo
{
    public abstract class SpecificMoney : Money
    {
        protected SpecificMoney(Currency currency) => Currency = currency;
        public Currency Currency { get; }

        public override SpecificMoney Of(Currency currency) 
            => currency.Equals(Currency) ? this : new EmptyMoney(currency);
        
        public abstract Tuple<Amount, Money> Take(decimal amount);
    }
}