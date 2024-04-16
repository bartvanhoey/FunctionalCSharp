namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.FunctionalDomainModelling;

// in OOP data and behavior live in the same object, and methods in the object can typically modify the object's state.

public class AccountOoC7
{
    public decimal Balance { get; private set; }

    public AccountOoC7(decimal balance) => Balance = balance;

    public void Debit(decimal amount)
    {
        if (Balance<amount)
            throw new InvalidOperationException("Insufficient fonds");

        Balance -= amount;
    }
}

// in FP data is captured with dumb data objects, behavior is encoded in functions