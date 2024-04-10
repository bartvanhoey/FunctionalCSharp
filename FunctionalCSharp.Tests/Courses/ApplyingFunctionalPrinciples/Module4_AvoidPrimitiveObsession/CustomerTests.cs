using Shouldly;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After.ResultErrors;

public class CustomerTests
{
    private const string ValidEmailAddress = "valid_email@hotmail.com";
    private const string InValidEmailAddress = "invalid_emailhotmail.com";
        
    [Fact]
    public void Test_Email_Implicit_Operator()
    {
        var emailResult = Email.Create(ValidEmailAddress);
        string email = emailResult.Value;

        email.ShouldBe(ValidEmailAddress);
    }

    [Fact]
    public void Test_Email_Explicit_Operator_ValidEmailAddress_Should_Return_Valid_Email()
    {
        var email = (Email)ValidEmailAddress;
        ((string) email).ShouldBe(ValidEmailAddress);
    }

    [Fact]
    public void Create_A_Customer_With_Correct_CustomerName_And_Email_Address_Should_Be_OK()
    {
        var customerNameResult = CustomerName.Create("Bart");
        customerNameResult.IsFailure.ShouldBeFalse();
        var customerName = customerNameResult.Value;

        var emailResult = Email.Create(ValidEmailAddress);
        emailResult.IsFailure.ShouldBeFalse();
        var email = emailResult.Value;
        var customer = new Customer(customerName, email);

        ((string)customer.Email).ShouldBe(ValidEmailAddress);
        ((string) customer.Name).ShouldBe("Bart");
    }

    [Fact]
    public void Create_Empty_CustomerName_Should_Fail()
    {
        var customerNameResult = CustomerName.Create("");
        customerNameResult.IsFailure.ShouldBeTrue();
        customerNameResult.Error.ShouldBeOfType<CustomerNameEmptyResultError>();
    }

    [Fact]
    public void Create_Too_Long_CustomerName_Should_Fail()
    {
        var customerNameResult = CustomerName.Create(
            "ddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd");
        customerNameResult.IsFailure.ShouldBeTrue();
        customerNameResult.Error.ShouldBeOfType<CustomerNameTooLongResultError>();
    }

    [Fact]
    public void Create_Too_Long_Email_Should_Fail()
    {
        var emailResult = Email.Create(
            "dddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddddd");
        emailResult.IsFailure.ShouldBeTrue();
        emailResult.Error.ShouldBeOfType<EmailTooLongResultError>();
    }

    [Fact]
    public void Create_Empty_Email_Should_Fail()
    {
        var emailResult = Email.Create("");
        emailResult.IsFailure.ShouldBeTrue();
        emailResult.Error.ShouldBeOfType<EmailEmptyResultError>();
    }

    [Fact]
    public void Create_Invalid_Email_Should_Fail()
    {
        var emailResult = Email.Create(InValidEmailAddress);
        emailResult.IsFailure.ShouldBeTrue();
        emailResult.Error.ShouldBeOfType<EmailInvalidResultError>();
    }

    [Fact]
    public void Create_Valid_Email_Should_Be_OK()
    {
        var emailResult = Email.Create(ValidEmailAddress);
        emailResult.IsFailure.ShouldBeFalse();
        ((string) emailResult.Value).ShouldBe(ValidEmailAddress);
    }
}
