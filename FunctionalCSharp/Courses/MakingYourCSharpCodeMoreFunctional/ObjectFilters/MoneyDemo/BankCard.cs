namespace FunctionalCSharp.Courses.MakingYourCSharpCodeMoreFunctional.ObjectFilters.MoneyDemo;

public class BankCard
{
    public DateTime ValidBefore { get;  }
    public decimal Balance { get; }

    public BankCard(DateTime validBefore, decimal balance)
    {
        ValidBefore = validBefore;
        Balance = balance;
    }

    public decimal GetAvailableAmount(decimal desired, DateTime at) 
        => at.CompareTo(ValidBefore) >= 0 ? 0 : Math.Min(Balance, desired);
}