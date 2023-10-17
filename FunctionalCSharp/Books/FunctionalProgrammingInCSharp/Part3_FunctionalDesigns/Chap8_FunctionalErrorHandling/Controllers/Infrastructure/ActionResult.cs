namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.Controllers.Infrastructure
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