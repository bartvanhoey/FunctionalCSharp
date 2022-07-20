namespace FunctionalCSharp.Functional.ObjectFilters.MoneyDemo
{
    public class EmptyMoney : SpecificMoney
    {
        public EmptyMoney(Currency currency) : base(currency)
        {
        }

        public override Money On(Timestamp time) => this;
        
        public override Tuple<Amount, Money> Take(decimal amount) => 
            Tuple.Create(Amount.Zero(Currency), (Money)this);
    }
}