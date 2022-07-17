using FunctionalCSharp.ApplyingFunctionalPrinciples.Exceptions.Errors.TicketController;
using FunctionalCSharp.Functional;
using FunctionalCSharp.Functional.ResultType;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.Exceptions.TestCase
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
            Date = date;
            CustomerName = customerName;
        }

        public DateTime Date { get; }
        public string CustomerName { get; }
    }

    public class TheaterApiClient
    {
        /// <summary>
        ///     Throws:
        ///     HttpRequestException if unable to connect to the API;
        ///     InvalidOperationException if no tickets are available
        /// </summary>
        public void Reserve(DateTime date, string customerName)
        {
        }
    }

    public class ActionResult
    {
        public ActionResult(string redirectTo)
        {
            RedirectTo = redirectTo;
            IsValid = true;
        }

        public ActionResult(string error, string? message)
        {
            Error = error;
            Message = message;
            IsValid = false;
            RedirectTo = "ErrorPage";
        }

        public string? Error { get; }
        public string? Message { get; }
        public string? RedirectTo { get; }

        // ReSharper disable once UnusedAutoPropertyAccessor.Local
        public bool IsValid { get; }
    }

    public class HttpPostAttribute : Attribute
    {
    }
}