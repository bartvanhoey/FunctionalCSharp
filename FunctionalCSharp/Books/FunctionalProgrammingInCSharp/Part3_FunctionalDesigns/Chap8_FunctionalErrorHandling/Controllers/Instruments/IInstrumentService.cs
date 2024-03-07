using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.Controllers.Instruments
{
    public interface IInstrumentService
    {
        Option<InstrumentDetails> GetInstrumentDetails(string ticker);
    }
}