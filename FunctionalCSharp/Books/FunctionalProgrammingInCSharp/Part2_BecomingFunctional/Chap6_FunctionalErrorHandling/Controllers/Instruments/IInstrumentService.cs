using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.Instruments;

public interface IInstrumentService
{
    Option<InstrumentDetails> GetInstrumentDetails(string ticker);
}