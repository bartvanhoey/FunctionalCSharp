using System.Net;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Start.Models;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Start.Controllers
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