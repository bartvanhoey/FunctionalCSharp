using System.ComponentModel.DataAnnotations;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.Before;

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
        try
        {
            Validate(date, customerName);
            _gateway.Reserve(date, customerName);
            var ticket = new Ticket(date, customerName);
            _repository.Save(ticket);
            return View("Success");
        }
        catch (Exception e)
        {
            return View("Error", e.Message);
        }
            
    }

    private void Validate(DateTime date, string customerName)
    {
        if (date.Date <DateTime.Now.Date)
            throw new ValidationException("Cannot reserve on a past date");

        if (string.IsNullOrWhiteSpace(customerName) || customerName.Length > 200)
            throw new ValidationException("Incorrect customer name");
    }


}