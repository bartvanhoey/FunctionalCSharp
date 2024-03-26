using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.Controllers.BookTransfers.Errors;

public record InvalidBic() : Error("The beneficiary's BIC/SWIFT code is invalid");