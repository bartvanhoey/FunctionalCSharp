using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.Instruments;
using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.Infrastructure
{
    public class Chapter06ControllerBase
    {
        public IActionResult Ok(InstrumentDetails details) 
            => new ActionResult(details.TickerName);
    
        public IActionResult Ok() 
            => new ActionResult();

        public IActionResult NotFound() 
            => new NotFoundActionResult();
        public IActionResult BadRequest(Error arg) 
            => new BadRequestActionResult();
    }
}