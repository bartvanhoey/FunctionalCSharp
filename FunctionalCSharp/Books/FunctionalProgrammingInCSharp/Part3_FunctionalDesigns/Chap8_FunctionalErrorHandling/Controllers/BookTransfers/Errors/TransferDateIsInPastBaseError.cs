using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.Controllers.BookTransfers.Errors;

public record TransferDateIsInPastBaseError() : Error("Transfer date cannot be in the past");