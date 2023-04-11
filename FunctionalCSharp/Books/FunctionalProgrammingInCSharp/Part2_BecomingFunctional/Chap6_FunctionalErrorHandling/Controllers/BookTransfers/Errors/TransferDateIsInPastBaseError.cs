using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.BookTransfers.Errors
{
    public record TransferDateIsInPastBaseError() : Error("Transfer date cannot be in the past");
}