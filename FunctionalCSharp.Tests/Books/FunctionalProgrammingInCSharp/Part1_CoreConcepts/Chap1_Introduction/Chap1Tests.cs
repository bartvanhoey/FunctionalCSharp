using FluentAssertions;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap1_Introduction;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap1_Introduction;

public class Chap1Tests
{
    [Fact]
    public void Test_GetNumbersMultipliedByThree()
    {
        var chap1 = new Chap1();
        var result = chap1.GetNumbersMultipliedByThree();
        result.Should().BeEquivalentTo(new[] { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30 });
    }

    [Fact]
    public void Test_GetNumbersMultipliedByThree_LocalFunction()
    {
        var chap1 = new Chap1();
        var result = chap1.GetNumbersMultipliedByThreeWithLocalFunction();
        result.Should().BeEquivalentTo(new[] { 3, 6, 9, 12, 15, 18, 21, 24, 27, 30 });
    }

    [Fact]
    public void LinqMethodsReturnANewList()
    {
        var chap1 = new Chap1();
        var result = chap1.LinqMethodsReturnANewList();
        result.Should().BeEquivalentTo(new[] { 7, 6, 1 });
    }

    [Fact]
    public void ExtensionMethodAsPairShouldReturnCorrectValues()
    {
        var (baseCurrency, quoteCurrency) = "EURUSD".AsPair();
        baseCurrency.Should().Be("EUR");
        quoteCurrency.Should().Be("USD");
    }

    [Fact]
    public void Method_GetNamesOfDaysStartWithS_Should_Return_Correct_Items()
    {
        var chap1 = new Chap1();
        // var result = chap1.GetNamesOfDaysStartWithS();
        var result = chap1.GetNamesOfDaysStartWithS();
        result.Should().BeEquivalentTo("Sunday", "Saturday");
    }

    [Fact]
    public void Method_GetEvensAndOdds_Should_Return_Correct_Items()
    {
        var chap1 = new Chap1();
        var (even, odd) = chap1.GetEvensAndOdds();
        even.Should().ContainInOrder(0, 2, 4, 6, 8);
        odd.Should().ContainInOrder(1, 3, 5, 7, 9);
    }

    [Fact]
    public void Method_GetOddNumbersWithMyWhereFunctional_Should_Return_Correct_Items()
    {
        var chap1 = new Chap1();
        var result = chap1.GetOddNumbersWithMyWhereFunctional();
        result.Should().BeEquivalentTo(new[] { 1, 3, 5, 7, 9 });
    }

    [Fact]
    public void Method_GetOddNumbersWithMyWhere_Should_Return_Correct_Items()
    {
        var chap1 = new Chap1();
        var result = chap1.GetOddNumbersWithMyWhere();
        result.Should().BeEquivalentTo(new[] { 1, 3, 5, 7, 9 });
    }

    [Fact]
    public void Method_Divide_Should_Return_Correct_Value()
    {
        var chap1 = new Chap1();
        var result = chap1.Divide();
        result.Should().Be(5);
    }

    [Fact]
    public void Test_Applying_SwapArgs_Extension_Method_On_DivideMethod_Should_Divide_With_Swapped_Arguments()
    {
        var chap1 = new Chap1();
        var result = chap1.DivideSwappedArgs();
        result.Should().Be(5);
    }
        
    [Fact]
    public void CalculateVat_Should_Return_The_Correct_Values()
    {
        var chap1 = new Chap1();
        var japanAddress = new Address("jp");
        var germanAddress = new Address("de");
        var auto = new Product("auto", 100, false);
        var potato = new Product("potato", 10, true);
            
        var japanAutoResult = chap1.CalculateVat(japanAddress, new Order(auto, 5));
        japanAutoResult.Should().Be(40);
            
        var germanAutoResult = chap1.CalculateVat(germanAddress, new Order(auto, 5));
        germanAutoResult.Should().Be(100);
            
        var germanPotatoResult = chap1.CalculateVat(germanAddress, new Order(potato, 5));
        germanPotatoResult.Should().Be(4);
    }
        
        
        
}