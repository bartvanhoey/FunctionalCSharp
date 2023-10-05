using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Models;
using static System.Net.HttpStatusCode;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Implement.Controllers.Base
{
    public class BaseController : ApiController
    {
        protected readonly UnitOfWork UnitOfWork;
        protected BaseController(UnitOfWork unitOfWork) => UnitOfWork = unitOfWork;

        protected static HttpResponseMessage ErrorResponse(string? errorMessage) 
            => Request.CreateResponse(BadRequest, Envelope.Error(errorMessage ?? "No error message provided"));

        protected HttpResponseMessage OkResponse()
        {
            UnitOfWork.Commit();
            return Request.CreateResponse(OK, Envelope.Ok());
        }

        protected HttpResponseMessage OkResponse<T>(T type)
        {
            UnitOfWork.Commit();
            return Request.CreateResponse(OK, Envelope.Ok(type));
        }
    }
}