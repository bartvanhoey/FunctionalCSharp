using System.Net;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.Models;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Infrastructure;
using Fupr.Functional.ResultClass.Errors;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.After.Controllers;

public class ControllerBase : ApiController
{
    protected readonly UnitOfWork UnitOfWork;

    protected ControllerBase(UnitOfWork unitOfWork)
    {
        UnitOfWork = unitOfWork;
            
    }

    protected static HttpResponseMessage HttpError(string? nameError) => Request.CreateResponse(HttpStatusCode.BadRequest, Envelope.Error(nameError ?? "no errormessage"));

    protected static HttpResponseMessage HttpError(BaseResultError? resultError) => Request.CreateResponse(HttpStatusCode.BadRequest, Envelope.Error(resultError?.Message ?? "no errormessage"));
    protected HttpResponseMessage HttpOk()
    {
        UnitOfWork.Commit();
        return Request.CreateResponse(HttpStatusCode.OK, Envelope.Ok());
    }
        
    protected HttpResponseMessage HttpOk<T>( T result)
    {
        UnitOfWork.Commit();
        return Request.CreateResponse(HttpStatusCode.OK, Envelope.Ok(result));
    }

    protected static HttpResponseMessage CustomerNotFound(long id) => HttpError($"Customer with such Id is not found: {id}");
}