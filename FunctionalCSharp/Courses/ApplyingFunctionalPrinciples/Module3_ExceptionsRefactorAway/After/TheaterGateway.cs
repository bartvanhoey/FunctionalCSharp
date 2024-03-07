using Fupr.Functional.ResultClass;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After.ResultErrors.Factory.ResultErrorFactory;
using static Fupr.Functional.ResultClass.Result;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After
{
    public class TheaterGateway
    {
        public Result Reserve(DateTime date, string customerName)
        {
            try
            {
                var client = new TheaterApiClient();
                client.Reserve(date, customerName);
            }
            catch (HttpRequestException httpRequestException)
            {
                return Fail(UnableToConnectToTheTheater);
            }
            catch (InvalidOperationException invalidOperationException)
            {
                return Fail(TicketsOnThisDateNoLongerAvailable);
            }
            return Ok();
        }
    }
}