using Shouldly;
using FunctionalCSharp.Courses.MakingYourCSharpCodeMoreFunctional.ObjectFilters.MoneyDemo;

namespace FunctionalCSharp.Tests.Courses.MakingYourCSharpCodeMoreFunctional.ObjectFilters;

public class BankCardTests
{
    [Fact]
    public void GetAvailableAmount_Method_Should_Return_Correct_Value()
    {
        var bankCard = new BankCard(DateTime.Now.AddSeconds(2), 100);
        var dateTimeNow = DateTime.Now;
                
                
        var availableAmount1 = bankCard.GetAvailableAmount(20, dateTimeNow);
        availableAmount1.ShouldBe(20);

        var availableAmount2 = bankCard.GetAvailableAmount(20, dateTimeNow);
        availableAmount2.ShouldBe(20);
            
        Thread.Sleep(3000);
        var availableAmount3 = bankCard.GetAvailableAmount(20,dateTimeNow);
        availableAmount3.ShouldBe(20);
            
            
    }
}