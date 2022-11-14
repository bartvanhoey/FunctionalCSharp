using FluentAssertions;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.CustomerName;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.Email;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.ValueObjects;

namespace FunctionalCSharp.Tests.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession
{
    public class CustomerTests
    {
        private const string ValidEmailAddress = "valid_email@hotmail.com";
        private const string InValidEmailAddress = "invalid_emailhotmail.com";

        // string emailString = emailResult.Type;
        //
        // var emailByString = (Email)"MyUserName@hotmail.com";         
        [Fact]
        public void Test_Email_Implicit_Operator()
        {
            var emailResult = Email.CreateEmail(ValidEmailAddress);
            string email = emailResult.Type;

            email.Should().Be(ValidEmailAddress);
        }

        [Fact]
        public void Test_Email_Explicit_Operator_ValidEmailAddress_Should_Return_Valid_Email()
        {
            var email = (Email)ValidEmailAddress;
            email.Value.Should().Be(ValidEmailAddress);
        }

        [Fact]
        public void Create_A_Customer_With_Correct_CustomerName_And_Email_Address_Should_Be_OK()
        {
            var customerNameResult = CustomerName.Create("Bart");
            customerNameResult.IsFailure.Should().BeFalse();
            var customerName = customerNameResult.Type;

            var emailResult = Email.CreateEmail(ValidEmailAddress);
            emailResult.IsFailure.Should().BeFalse();
            var email = emailResult.Type;
            var customer = new Customer(customerName, email);

            customer.Email.Value.Should().Be(ValidEmailAddress);
            customer.CustomerName.Value.Should().Be("Bart");
        }

        [Fact]
        public void Create_Empty_CustomerName_Should_Fail()
        {
            var customerNameResult = CustomerName.Create("");
            customerNameResult.IsFailure.Should().BeTrue();
            customerNameResult.Error.Should().BeOfType<CustomerNameEmptyError>();
        }

        [Fact]
        public void Create_Too_Long_CustomerName_Should_Fail()
        {
            var customerNameResult = CustomerName.Create(
                "ddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd");
            customerNameResult.IsFailure.Should().BeTrue();
            customerNameResult.Error.Should().BeOfType<CustomerNameTooLongError>();
        }

        [Fact]
        public void Create_Too_Long_Email_Should_Fail()
        {
            var emailResult = Email.CreateEmail(
                "dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd");
            emailResult.IsFailure.Should().BeTrue();
            emailResult.Error.Should().BeOfType<EmailTooLongError>();
        }

        [Fact]
        public void Create_Empty_Email_Should_Fail()
        {
            var emailResult = Email.CreateEmail("");
            emailResult.IsFailure.Should().BeTrue();
            emailResult.Error.Should().BeOfType<EmailEmptyError>();
        }

        [Fact]
        public void Create_Invalid_Email_Should_Fail()
        {
            var emailResult = Email.CreateEmail(InValidEmailAddress);
            emailResult.IsFailure.Should().BeTrue();
            emailResult.Error.Should().BeOfType<EmailInvalidError>();
        }

        [Fact]
        public void Create_Valid_Email_Should_Be_OK()
        {
            var emailResult = Email.CreateEmail(ValidEmailAddress);
            emailResult.IsFailure.Should().BeFalse();
            emailResult.Type.Value.Should().Be(ValidEmailAddress);
        }
    }
}