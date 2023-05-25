using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.Infrastructure;
using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.
    Instruments
{
    public class Chapter06Controller : Chapter06ControllerBase
    {
        private readonly Func<string, Option<InstrumentDetails>> _getInstrumentsDetails;

        public Chapter06Controller(IInstrumentService service) 
            => _getInstrumentsDetails = service.GetInstrumentDetails;

        public IActionResult GetInstrumentDetails(string ticker) 
            => _getInstrumentsDetails(ticker).Match(NotFound, Ok);
    }
}