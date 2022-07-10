using System.Net;
using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Controllers.Models;
using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel;
using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Model;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Controllers
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