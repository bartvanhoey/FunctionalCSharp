namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.BookTransfers.Errors;

public abstract class BaseError
{
    public abstract string? Message { get; }
}