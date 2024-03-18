using FluentAssertions;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.BankOfCodeland;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.BankOfCodeland.Validators;

namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionPurity.BankOfCodeland;

public class BankOfCodelandTests
{

    [Fact]
    public void WhenTransferDateIsFuture_ThenValidationPasses()
    {
        var sut = new DateNotPastValidator();

        var transfer = MakeTransfer.Dummy with
        {
            Date =DateTime.Now.AddDays(1)
        };
        sut.IsValid(transfer).Should().BeTrue();
    }
    
    [Fact]
    public void WhenTransferDateIsPast_ThenValidationDoesNotPass()
    {
        var sut = new DateNotPastValidator();

        var transfer = MakeTransfer.Dummy with
        {
            Date = DateTime.Now.AddDays(-1)
        };

        sut.IsValid(transfer).Should().BeFalse();
    }
    
    
    
    // [Theory]
    // [InlineData(1,true)]
    // [InlineData(0, true)]
    // [InlineData(-1, false)]
    // // [InlineData(int.MinValue, false)] => throws ArgumentException
    // public void DateNotPastValidator_ShouldPassWhenTransferDateInFuture(int numberOfDays, bool expected)
    // {
    //     var transfer = new MakeTransfer {Date = DateTime.UtcNow.AddDays(numberOfDays)} ;
    //     var validator = new DateNotPastValidator(new FakeTimeService());
    //
    //     var result = validator.IsValid(transfer);
    //     result.Should().Be(expected);
    // }
    //     
    // [Theory]
    // [InlineData(1,true)]
    // [InlineData(0, true)]
    // [InlineData(-1, false)]
    // // [InlineData(int.MinValue, false)] => throws ArgumentException
    // public void FunctionalDateNotPastValidator_ShouldPassWhenTransferDateInFuture(int numberOfDays, bool expected)
    // {
    //     var transfer = new MakeTransfer {Date = DateTime.UtcNow.AddDays(numberOfDays)} ;
    //     var validator = new FunctionalDateNotPastValidator(DateTime.Now);
    //
    //     var result = validator.IsValid(transfer);
    //     result.Should().Be(expected);
    // }
    //     
    // [Theory]
    // [InlineData("ABCDEFGJ123",true)]
    // [InlineData("XXXXXXXXXXX", false)]
    // public void BicExistsValidator_ShouldPass(string codes, bool expected)
    // {
    //     IEnumerable<string> validCodes = new []{ "ABCDEFGJ123"};
    //     var validator = new BicExistsValidator(() => validCodes);
    //
    //     var transfer = new MakeTransfer {Bic = codes};
    //     var result = validator.IsValid(transfer);
    //     result.Should().Be(expected);
    // }
}