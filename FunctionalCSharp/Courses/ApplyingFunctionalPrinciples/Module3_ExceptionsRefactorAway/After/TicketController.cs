using Fupr;
using Fupr.Functional.ResultClass;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After.ResultErrors.Factory.ResultErrorFactory;
using static Fupr.Functional.ResultClass.Result;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After;

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
        var validationResult = Validate(date, customerName);
        if (validationResult.IsFailure) return View("Error", validationResult.Error?.Message);

        var reserveResult = _gateway.Reserve(date, customerName);
        if (reserveResult.IsFailure) return View("Error", reserveResult.Error?.Message);

        var ticket = new Ticket(date, customerName);
        _repository.Save(ticket);
        return View("Success");
    }

    private Result Validate(DateTime date, string customerName)
    {
        if (date.Date < DateTime.Now.Date) return Fail(CannotReserveOnAPastDate);

        if (customerName.IsNullOrWhiteSpace() || customerName.Length > 200)
            return Fail(IncorrectCustomerName);

        return Ok();
    }
}