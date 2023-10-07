using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.After;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.TestCase;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.ValueObjects;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.Before
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
            ModelState.SetIsValidToTrue();
            if (!ModelState.IsValid)
            {
                return View(customerModel);
            }

            var customer = new Customer(customerModel.Name, customerModel.Email);
           _database.Save(customer);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Index(int id)
        {
            return View();
        }
    }
}