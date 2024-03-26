using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_DesigningProgramsWithFunctionComposition.Newsletter;
using Shouldly;
using static Xunit.Assert;


namespace FunctionalCSharp.Tests.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap5_ModellingDataAbsence;

public class NewsLetterTests
{
    [Theory]
    [InlineData("Bart", "bart@test.mail", "Dear BART,")]
    public void GreetingFor_Returns_Correct_Greeting_When_Name_Is_Not_Null(string name, string email, string expected)
    {
        var subscriber = new Subscriber(name, email);

        var result = NewsLetterService.GreetingFor(subscriber);
        
        result.ShouldBe(expected);
    }
    
    
    [Theory]
    [InlineData(null, "bart@test.mail")]
    public void GreetingFor_Throws_ArgumentOutOfRangeException_When_Name_IsNull(string name, string email)
    {
        var subscriber = new Subscriber(name, email);
        
        Throws<ArgumentOutOfRangeException>(() =>NewsLetterService.GreetingFor(subscriber));
    }

    
    [Theory]
    [InlineData("Bart", "bart@test.mail", "Dear BART,")]
    [InlineData(null, "bart@test.mail", "Dear Subscriber,")]
    public void OptGreetingFor(string? name, string email, string expected)
    {
        var subscriber = new OptSubscriber(name, email);

        var result = NewsLetterService.OptGreetingFor(subscriber);
        
        result.ShouldBe(expected);
    }
    
}