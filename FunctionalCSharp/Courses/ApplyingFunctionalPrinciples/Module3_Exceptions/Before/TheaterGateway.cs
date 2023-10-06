using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.After;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.After.Errors.TicketController;
using FunctionalCSharp.Functional.ResultClass;
using static FunctionalCSharp.Functional.ResultClass.Result;

// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.Before
{
    public class TheaterGateway
    {
        public void Reserve(DateTime date, string customerName)
        {
            var client = new TheaterApiClient();
            client.Reserve(date,customerName);
        }
    }
}