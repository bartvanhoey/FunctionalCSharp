using FunctionalCSharp.Exceptions.ResultClass.TestCase;
using FunctionalCSharp.NullOptionType;
using FunctionalCSharp.PrimitiveObsession.ValueObjects;

namespace FunctionalCSharp.PrimitiveObsession.TestCase
{
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
            ModelState.Init();
            var customerName = CustomerName.Create(customerModel.Name);
            var email = Email.Create(customerModel.Email);

            if (customerName.IsFailure) ModelState.AddModelError("Name", customerName.Error);
            
            if (email.IsFailure) ModelState.AddModelError("Email", email.Error);

            if (!ModelState.IsValid) 
                return View("error", "invalid customer model");

            var customer = new Customer(customerName.Type, email.Type); 
            _database.Save(customer);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            var customer = _database.GetById(id);
            return customer.HasNoValue ? HttpNotFound() : View(customer.Type.CustomerName);
        }

        private ActionResult RedirectToAction(string redirectTo) => new(redirectTo);
    }

    public class HttpGetAttribute : Attribute
    {
    }
}