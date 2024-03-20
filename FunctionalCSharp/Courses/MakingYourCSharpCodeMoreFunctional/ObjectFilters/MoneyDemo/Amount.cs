namespace FunctionalCSharp.Courses.MakingYourCSharpCodeMoreFunctional.ObjectFilters.MoneyDemo;

public class Amount : SpecificMoney
{
    public decimal Value { get; }

    public Amount(Currency currency, decimal amount) : base(currency)
    {
        if (amount < 0)
            throw new ArgumentException("Negative amount.");
        Value = amount;
    }

    public override Money On(Timestamp time) => this;

    public override (Amount taken, Money remaining) Take(decimal amount)
    {
        var taken = Math.Min(Value, amount);
        var remaining = Value - taken;

        return (new Amount(Currency, taken), new Amount(Currency, remaining));
    }

    public static Amount Zero(Currency currency) => new(currency, 0);
}