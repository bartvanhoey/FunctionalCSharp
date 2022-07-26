using System.Net;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.Controllers.Models;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.Controllers
{
    public class Request
    {
        public static HttpResponseMessage CreateResponse(HttpStatusCode internalServerError, Envelope error)
        {
            throw new NotImplementedException();
        }

        public static HttpResponseMessage CreateResponse(HttpStatusCode internalServerError, Envelope<MyCustomer> error)
        {
            throw new NotImplementedException();
        }

        public static HttpResponseMessage CreateResponse<T>(HttpStatusCode internalServerError, Envelope<T> error)
        {
            throw new NotImplementedException();
        }
    }
}