using FunctionalCSharp.MyYumba;
using static FunctionalCSharp.MyYumba.Y;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.
    FunctionalDomainModelling;

public static class AccountStateExtensions
{
    public static YOption<AccountState> Debit(this AccountState current, decimal amount)
        => current.Balance < amount ? YNone : YSome(new AccountState(current.Balance - amount));
}