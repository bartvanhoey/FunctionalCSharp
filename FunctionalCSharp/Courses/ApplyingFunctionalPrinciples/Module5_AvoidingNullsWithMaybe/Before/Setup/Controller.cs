namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module5_AvoidingNullsWithMaybe.Before.Setup;

public class Controller
{
    protected ActionResult View(string error, string? message)
    {
        return new(error, message);
    }

    protected ActionResult View(string redirect)
    {
        return new(redirect);
    }

    protected ActionResult HttpNotFound()
    {
        return new("NotFound");
    }


    protected ActionResult View(CustomerModel customerModel)
    {
        return new ActionResult("customerModel");
    }

    protected ActionResult View()
    {
        return new ActionResult("Index");
    }

    protected ActionResult RedirectToAction(string redirectTo)
    {
        return new(redirectTo);
    }

    protected ActionResult View(Customer customerModel)
    {
        return new("customerModel");
    }

    
}