namespace FunctionalCSharp.Courses.MakingYourCSharpCodeMoreFunctional.ObjectFilters.MoneyDemo;

public class EmptyMoney : SpecificMoney
{
    public EmptyMoney(Currency currency) : base(currency)
    {
    }

    public override Money On(Timestamp time) => this;
        
    public override (Amount, Money) Take(decimal amount) 
        => (Amount.Zero(Currency), this);
}