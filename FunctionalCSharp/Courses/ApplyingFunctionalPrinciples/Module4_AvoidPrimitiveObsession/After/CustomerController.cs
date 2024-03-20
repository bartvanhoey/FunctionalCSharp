using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After.Setup;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.After;

public class CustomerController : Controller
{
    private readonly IDatabase _database;

    public CustomerController(IDatabase database)
    {
        _database = database;
    }


    [HttpPost]
    public ActionResult CreateCustomer(CustomerModel customerModel)
    {
        ModelState.SetIsValidToTrue();

        var customerNameResult = CustomerName.Create(customerModel.Name);
        var emailResult = Email.Create(customerModel.Email);
            
        if (customerNameResult.IsFailure) ModelState.AddModelError("Name", customerNameResult.Error);
        if (emailResult.IsFailure) ModelState.AddModelError("Name", emailResult.Error);

        if (!ModelState.IsValid) return View("ErrorPage", "");

        var customer = new Customer(customerNameResult.Value, emailResult.Value);
        _database.Save(customer);

        return RedirectToAction("Index");
    }

    [HttpGet]
    public ActionResult Index(int id)
    {
        return id switch
        {
            1 => View("MyUserName"),
            -1 => View("NotFound"),
            _ => View()
        };
    }
}