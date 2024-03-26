using System.Net;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Before.Models;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module7_AllTogether.Infrastructure;

public class Request
{
    public static HttpResponseMessage CreateResponse(HttpStatusCode statusCode, Envelope error) => new(statusCode);

    public static HttpResponseMessage CreateResponse(HttpStatusCode statusCode, Envelope<Customer> error) =>
        new(statusCode);

    public static HttpResponseMessage CreateResponse<T>(HttpStatusCode statusCode, Envelope<T> error) =>
        new(statusCode);
}