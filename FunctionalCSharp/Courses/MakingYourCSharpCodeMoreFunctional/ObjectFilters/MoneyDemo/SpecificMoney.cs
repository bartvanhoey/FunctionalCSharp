namespace FunctionalCSharp.Courses.MakingYourCSharpCodeMoreFunctional.ObjectFilters.MoneyDemo;

public abstract class SpecificMoney : Money
{
    protected SpecificMoney(Currency currency) => Currency = currency;
    public Currency Currency { get; }

    public override SpecificMoney Of( Currency currency)
    {
        return currency.Equals(Currency) ? this : new EmptyMoney(currency);
    }
    
    public abstract (Amount taken, Money remaining) Take(decimal amount);
}