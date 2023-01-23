namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.BookTransfers.Errors;

public class TransferDateIsInPastBaseError : BaseError
{
    public override string? Message { get; } = "Transfer date cannot be in the past";
}