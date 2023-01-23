using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.Instruments;

public class InstrumentService : IInstrumentService
{
    public Option<InstrumentDetails> GetInstrumentDetails(string ticker) =>
        ticker switch
        {
            "AAPL" => F.Some(new InstrumentDetails("Apple Inc", "AAPL")),
            "GOOG" => F.Some(new InstrumentDetails("Google", "GOOG")),
            "MSFT" => F.Some(new InstrumentDetails("Microsoft Corp", "MSFT")),
            _ => F.None
        };
}