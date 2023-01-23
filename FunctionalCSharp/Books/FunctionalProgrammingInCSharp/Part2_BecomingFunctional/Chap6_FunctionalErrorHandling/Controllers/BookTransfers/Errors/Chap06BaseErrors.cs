namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.BookTransfers.Errors;

public static class Chap06BaseErrors
{
    public static InvalidBic InvalidBic => new InvalidBic();
    public static TransferDateIsInPastBaseError TransferDateIsInPastBaseError => new TransferDateIsInPastBaseError();
}