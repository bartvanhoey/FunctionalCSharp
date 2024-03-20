using FluentAssertions;
using FunctionalCSharp.Courses.MakingYourCSharpCodeMoreFunctional.ObjectFilters.MoneyDemo;

namespace FunctionalCSharp.Tests.Courses.MakingYourCSharpCodeMoreFunctional.ObjectFilters.MoneyDemo;

public class MoneyDemoTests
{
    [Fact]
    public void TestWalletClass()
    {
        var wallet = new Wallet();
            
        wallet.Add(new Amount(Currency.Eur, 100));
        wallet.Add(new Amount(Currency.Eur, 100));
        wallet.Add(new Amount(Currency.Eur, 100));
        wallet.Add(new Amount(Currency.Usd, 40));
        wallet.Add(new Amount(Currency.Usd, 600));
        wallet.Add(new Amount(Currency.Jpy, 20));
        wallet.Add(new Amount(Currency.Jpy, 20));

        var charge = wallet.Charge(Currency.Eur, new Amount(Currency.Eur, 100));

        charge.Value.Should().Be(100);

    }
}