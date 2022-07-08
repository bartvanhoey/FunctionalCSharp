using FunctionalCSharp.Exceptions.ResultClass.Errors;

namespace FunctionalCSharp.Exceptions.ResultClass.TestCase
{
    public class TheaterGateway
    {
        public Result Reserve(DateTime date, string customerName)
        {
            try
            {
                var client = new TheaterApiClient();
                client.Reserve(date, customerName);

                return Result.Ok();
            }
            catch (HttpRequestException)
            {
                return Result.Fail(new UnableToConnectToTheTheaterError());
            }
            catch (InvalidOperationException)
            {
                return Result.Fail(new TicketsOnThisDateNoLongerAvailableError());
            }
        }
    }
    public class Controller
    {
        protected ActionResult View(string error, string? message = null) => new(error, message);
    }
    
    public class TicketRepository
    {
        public void Save(Ticket ticket)
        {
        }
    }
    
    public class Ticket
    {
        public Ticket(DateTime date, string customerName)
        {
        }
    }
    public class TheaterApiClient
    {
        /// <summary>
        /// Throws:
        /// HttpRequestException if unable to connect to the API;
        /// InvalidOperationException if no tickets are available
        /// </summary>
        public void Reserve(DateTime date, string customerName)
        {
            
        }
    }
    
    public class ActionResult
    {
        public string Error { get; }
        public string? Message { get; }

        public ActionResult(string error, string? message)
        {
            Error = error;
            Message = message;
        }
    }
    
    public class HttpPostAttribute : Attribute
    {
    }
    
}