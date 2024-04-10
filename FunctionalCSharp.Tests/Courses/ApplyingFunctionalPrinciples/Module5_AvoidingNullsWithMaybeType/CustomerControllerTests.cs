using Shouldly;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After.Setup;

namespace FunctionalCSharp.Tests.Courses.ApplyingFunctionalPrinciples.Module5_AvoidingNullsWithMaybeType;

public class CustomerControllerTests
{
    [Fact]
    public void Method_Index_Should_Return_HttpNotFound_When_Id_Is_Minus_One()
    {
        var customerController = GetCustomerController();
        var actionResult = customerController.Index(-1);
        actionResult.RedirectTo.ShouldBe("NotFound");
    }

    [Fact]
    public void Method_Index_Should_Return_HttpNotFound_When_Id_Is_One()
    {
        var customerController = GetCustomerController();
        var actionResult = customerController.Index(1);
        actionResult.RedirectTo.ShouldBe("MyUserName");
    }

    private CustomerController GetCustomerController() => new(new Database());
}