namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.BookTransfers.Errors;

public class InvalidBic : BaseError
{
    public override string? Message { get; } = "The beneficiary's BIC/SWIFT code is invalid";
}