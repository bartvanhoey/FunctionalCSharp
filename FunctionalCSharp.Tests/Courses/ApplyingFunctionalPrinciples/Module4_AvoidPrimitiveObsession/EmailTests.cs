using Shouldly;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After.ResultErrors;

namespace FunctionalCSharp.Tests.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession;

public class EmailTests
{
    private const string ValidEmailAddress = "valid_email@hotmail.com";
        
    [Fact]
    public void Explicit_Operator_ValidEmailAddress_Should_Return_IsSuccess()
    {
        var email = (Email)ValidEmailAddress; // Explicit operator
        ((string)email).ShouldBe(ValidEmailAddress);
    }
        
    [Fact]
    public void EmptyEmailShouldThrowEmailEmptyError()
    {
        var result = Email.Create("");
        result.IsFailure.ShouldBeTrue();
        result.Error.ShouldBeOfType<EmailEmptyResultError>();
    }

    [Fact]
    public void NullEmailShouldThrowEmailEmptyError()
    {
        var result = Email.Create(null);
        result.IsFailure.ShouldBeTrue();
        result.Error.ShouldBeOfType<EmailEmptyResultError>();
    }
        
    [Fact]
    public void EmailTooLongShouldThrowEmailTooLongError()
    {
        var result = Email.Create("emailtoolongddkdkdkkdkdkdkkdkdkkdkkdkdkkdkdkkdkdkdkdkdkkkkdkkdkdkdkkdkdkkdkddkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkddkdkdkkddkkdkdkdkkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdk@hotmail.com");
        result.IsFailure.ShouldBeTrue();
        result.Error.ShouldBeOfType<EmailTooLongResultError>();
    }

    [Fact]
    public void ValidEmailShouldReturnIsSuccess()
    {
        var result = Email.Create(ValidEmailAddress);
        result.IsSuccess.ShouldBeTrue();
        ((string)result.Value).ShouldBe(ValidEmailAddress);
    }
        
    [Fact]
    public void InValidEmailShouldReturnIsSuccess()
    {
        var result = Email.Create("invalid_emailhotmail.com");
        result.IsSuccess.ShouldBeFalse();
    }

        
        
}