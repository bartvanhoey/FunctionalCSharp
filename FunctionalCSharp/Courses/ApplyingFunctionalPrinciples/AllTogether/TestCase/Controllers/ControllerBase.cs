using System.Net;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.Controllers.Models;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.Logic;
using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.Controllers
{
    public class ControllerBase : ApiController
    {
        private readonly UnitOfWork _uow;

        protected ControllerBase(UnitOfWork uow)
        {
            _uow = uow;
        }

        protected HttpResponseMessage BadRequest(string errorMessage)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest, Envelope.Error(errorMessage));
        }

        protected HttpResponseMessage Ok()
        {
            _uow.Commit();
            return Request.CreateResponse(HttpStatusCode.OK, Envelope.Ok());
        }

        protected HttpResponseMessage BadRequest(BaseError? error)
        {
            return Request.CreateResponse(HttpStatusCode.BadRequest,
                Envelope.Error(error?.Message ?? "error not specified"));
        }

        protected HttpResponseMessage Ok<T>(T result)
        {
            _uow.Commit();
            return Request.CreateResponse(HttpStatusCode.OK, Envelope.Ok(result));
        }
    }
}