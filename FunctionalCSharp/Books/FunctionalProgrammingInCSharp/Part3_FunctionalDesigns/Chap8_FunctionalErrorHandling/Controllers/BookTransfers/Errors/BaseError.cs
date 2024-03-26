namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.Controllers.BookTransfers.Errors;

public abstract class BaseError
{
    public abstract string? Message { get; }
}