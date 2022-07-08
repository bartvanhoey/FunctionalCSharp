using FluentAssertions;
using FunctionalCSharp.Exceptions.ResultClass.Errors.CustomerName;
using FunctionalCSharp.Exceptions.ResultClass.Errors.Email;
using FunctionalCSharp.PrimitiveObsession;
using FunctionalCSharp.PrimitiveObsession.ValueObjects;

namespace FunctionalCSharp.Tests.PrimitiveObsession
{
    public class CustomerTests
    {
        
        [Fact]
        public void Create_A_Customer_With_Correct_CustomerName_And_Email_Address_Should_Be_OK()
        {
            var customerNameResult = CustomerName.Create("Bart");
            customerNameResult.IsFailure.Should().BeFalse();
            var customerName = customerNameResult.Type;

            var emailResult = Email.Create("bartvanhoey@hotmail.com");
            emailResult.IsFailure.Should().BeFalse();
            var email = emailResult.Type;
            
            var customer = new Customer(customerName, email);

            customer.Email.Value.Should().Be("bartvanhoey@hotmail.com");
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
            var customerNameResult = CustomerName.Create("ddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd");
            customerNameResult.IsFailure.Should().BeTrue();
            customerNameResult.Error.Should().BeOfType<CustomerNameTooLongError>();
        }
        
        [Fact]
        public void Create_Too_Long_Email_Should_Fail()
        {
            var emailResult = Email.Create("dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd");
            emailResult.IsFailure.Should().BeTrue();
            emailResult.Error.Should().BeOfType<EmailTooLongError>();
        }
        
        [Fact]
        public void Create_Empty_Email_Should_Fail()
        {
            var emailResult = Email.Create("");
            emailResult.IsFailure.Should().BeTrue();
            emailResult.Error.Should().BeOfType<EmailEmptyError>();
        }
        
        [Fact]
        public void Create_Invalid_Email_Should_Fail()
        {
            var emailResult = Email.Create("bartvanhoeyhotmail.com");
            emailResult.IsFailure.Should().BeTrue();
            emailResult.Error.Should().BeOfType<EmailInvalidError>();
        }
        
        [Fact]
        public void Create_Valid_Email_Should_Be_OK()
        {
            var emailResult = Email.Create("bartvanhoey@hotmail.com");
            emailResult.IsFailure.Should().BeFalse();
            emailResult.Type.Value.Should().Be("bartvanhoey@hotmail.com");
        }
        
        
    }
    
}