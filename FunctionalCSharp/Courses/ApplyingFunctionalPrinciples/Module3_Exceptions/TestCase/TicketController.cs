using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.TicketController;
using FunctionalCSharp.Functional.ResultClass;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase
{
    public class TicketController : Controller
    {
        private readonly TheaterGateway _gateway;
        private readonly TicketRepository _repository;

        public TicketController(TicketRepository repository, TheaterGateway gateway)
        {
            _gateway = gateway;
            _repository = repository;
        }


        public ActionResult BuyTicket(DateTime date, string customerName)
        {
            var validationResult = ValidateBuyTicketInput(date, customerName);
            if (validationResult.IsFailure)
                return View("Error", validationResult.Error?.Message);

            var reserveResult = _gateway.Reserve(date, customerName);
            if (reserveResult.IsFailure)
                return View("Error", reserveResult.Error?.Message);

            var ticket = new Ticket(date, customerName);
            _repository.Save(ticket);

            return View("Success");
        }

        private Result ValidateBuyTicketInput(DateTime date, string customerName)
        {
            if (date.Date < DateTime.Now.Date)
                return Result.Fail(new CannotReserveOnAPastDateError());

            if (string.IsNullOrWhiteSpace(customerName) || customerName.Length > 200)
                return Result.Fail(new IncorrectCustomerNameError());

            return Result.Ok();
        }
    }
}