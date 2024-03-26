using FluentAssertions;
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
        ((string)email).Should().Be(ValidEmailAddress);
    }
        
    [Fact]
    public void EmptyEmailShouldThrowEmailEmptyError()
    {
        var result = Email.Create("");
        result.IsFailure.Should().BeTrue();
        result.Error.Should().BeOfType<EmailEmptyResultError>();
    }

    [Fact]
    public void NullEmailShouldThrowEmailEmptyError()
    {
        var result = Email.Create(null);
        result.IsFailure.Should().BeTrue();
        result.Error.Should().BeOfType<EmailEmptyResultError>();
    }
        
    [Fact]
    public void EmailTooLongShouldThrowEmailTooLongError()
    {
        var result = Email.Create("emailtoolongddkdkdkkdkdkdkkdkdkkdkkdkdkkdkdkkdkdkdkdkdkkkkdkkdkdkdkkdkdkkdkddkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkddkdkdkkddkkdkdkdkkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdk@hotmail.com");
        result.IsFailure.Should().BeTrue();
        result.Error.Should().BeOfType<EmailTooLongResultError>();
    }

    [Fact]
    public void ValidEmailShouldReturnIsSuccess()
    {
        var result = Email.Create(ValidEmailAddress);
        result.IsSuccess.Should().BeTrue();
        ((string)result.Value).Should().Be(ValidEmailAddress);
    }
        
    [Fact]
    public void InValidEmailShouldReturnIsSuccess()
    {
        var result = Email.Create("invalid_emailhotmail.com");
        result.IsSuccess.Should().BeFalse();
    }

        
        
}