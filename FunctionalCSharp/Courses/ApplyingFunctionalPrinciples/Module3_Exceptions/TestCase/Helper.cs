using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase.Errors.TicketController;
using FunctionalCSharp.Functional.ResultClass;
using static FunctionalCSharp.Functional.ResultClass.Result;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase
{
    public class TheaterGateway
    {
        public Result Reserve(DateTime date, string customerName)
        {
            try
            {
                var client = new TheaterApiClient();
                client.Reserve(date, customerName);
                return Ok();
            }
            catch (HttpRequestException)
            {
                return Fail(new UnableToConnectToTheTheaterError());
            }
            catch (InvalidOperationException)
            {
                return Fail(new TicketsOnThisDateNoLongerAvailableError());
            }
        }
    }
}