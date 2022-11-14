using System.Net;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Models;
using Customer = FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Start.Models.Customer;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Controllers.Base
{
    public class Request
    {
        public static HttpResponseMessage CreateResponse(HttpStatusCode internalServerError, Envelope error)
        {
            throw new NotImplementedException();
        }

        public static HttpResponseMessage CreateResponse(HttpStatusCode internalServerError, Envelope<Customer> error)
        {
            throw new NotImplementedException();
        }

        public static HttpResponseMessage CreateResponse<T>(HttpStatusCode internalServerError, Envelope<T> error)
        {
            throw new NotImplementedException();
        }
    }
}