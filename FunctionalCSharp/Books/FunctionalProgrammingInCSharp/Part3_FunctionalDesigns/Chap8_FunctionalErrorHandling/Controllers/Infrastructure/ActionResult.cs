namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.Infrastructure
{
    public class ActionResult : IActionResult
    {
        public string? TickerName { get; }

        public ActionResult(string? tickerName = null)
        {
            TickerName = tickerName;
        }
    }
}