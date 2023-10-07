using FluentAssertions;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After.Setup;

namespace FunctionalCSharp.Tests.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession
{
    public class CustomerControllerTests
    {
        private const string ValidName = "John Doe";
        private const string ValidEmailAddress = "valid_email@hotmail.com";
        private const string InValidEmailAddress = "valid_emailhotmail.com";

        [Fact]
        public void Method_CreateCustomer_With_Valid_CustomerModel_Input_Should_GoTo_Index_Action_Result()
        {
            var controller = GetCustomerController();

            var customerModel = new CustomerModel(ValidName, ValidEmailAddress);
            var actionResult = controller.CreateCustomer(customerModel);

            actionResult.RedirectTo.Should().Be("Index");
        }

        [Fact]
        public void Method_CreateCustomer_With_CustomerModel_Input_Invalid_Email_Should_GoTo_Index_Action_Result()
        {
            var controller = GetCustomerController();

            var customerModel = new CustomerModel(ValidName, InValidEmailAddress);
            var actionResult = controller.CreateCustomer(customerModel);

            actionResult.RedirectTo.Should().Be("ErrorPage");
        }

        [Fact]
        public void Method_CreateCustomer_With_CustomerModel_Input_Invalid_Name_Should_GoTo_Index_Action_Result()
        {
            var controller = GetCustomerController();

            var customerModel = new CustomerModel("", ValidEmailAddress);
            var actionResult = controller.CreateCustomer(customerModel);

            actionResult.RedirectTo.Should().Be("ErrorPage");
        }

        [Fact]
        public void Method_CreateCustomer_With_Invalid_CustomerModel_Input_Should_GoTo_Index_Action_Result()
        {
            var controller = GetCustomerController();

            var customerModel = new CustomerModel("", InValidEmailAddress);
            var actionResult = controller.CreateCustomer(customerModel);

            actionResult.RedirectTo.Should().Be("ErrorPage");
        }

        [Fact]
        public void Method_CreateCustomer_With_Invalid_CustomerModel_dInput_Should_GoTo_Index_Action_Result()
        {
            var controller = GetCustomerController();

            var customerModel = new CustomerModel(" ", InValidEmailAddress);
            var actionResult = controller.CreateCustomer(customerModel);

            actionResult.RedirectTo.Should().Be("ErrorPage");
        }

        private CustomerController GetCustomerController()
        {
            return new(new Database());
        }
    }
}