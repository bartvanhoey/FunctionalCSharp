using FluentAssertions;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.Email;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.ValueObjects;

namespace FunctionalCSharp.Tests.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession
{
    public class EmailTests
    {
        private const string ValidEmailAddress = "valid_email@hotmail.com";
        
        [Fact]
        public void Explicit_Operator_ValidEmailAddress_Should_Return_IsSuccess()
        {
            var email = (Email)ValidEmailAddress; // Explicit operator
            email.Value.Should().Be(ValidEmailAddress);
        }
        
        [Fact]
        public void EmptyEmailShouldThrowEmailEmptyError()
        {
            var result = Email.CreateEmail("");
            result.IsFailure.Should().BeTrue();
            result.Error.Should().BeOfType<EmailEmptyError>();
        }

        [Fact]
        public void NullEmailShouldThrowEmailEmptyError()
        {
            var result = Email.CreateEmail(null);
            result.IsFailure.Should().BeTrue();
            result.Error.Should().BeOfType<EmailEmptyError>();
        }
        
        [Fact]
        public void EmailTooLongShouldThrowEmailTooLongError()
        {
            var result = Email.CreateEmail("emailtoolongddkdkdkkdkdkdkkdkdkkdkkdkdkkdkdkkdkdkdkdkdkkkkdkkdkdkdkkdkdkkdkddkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkddkdkdkkddkkdkdkdkkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdkdk@hotmail.com");
            result.IsFailure.Should().BeTrue();
            result.Error.Should().BeOfType<EmailTooLongError>();
        }

        [Fact]
        public void ValidEmailShouldReturnIsSuccess()
        {
            var result = Email.CreateEmail(ValidEmailAddress);
            result.IsSuccess.Should().BeTrue();
            result.Type.Value.Should().Be(ValidEmailAddress);
        }
        
        [Fact]
        public void InValidEmailShouldReturnIsSuccess()
        {
            var result = Email.CreateEmail("invalid_emailhotmail.com");
            result.IsSuccess.Should().BeFalse();
        }

        
        
    }
}