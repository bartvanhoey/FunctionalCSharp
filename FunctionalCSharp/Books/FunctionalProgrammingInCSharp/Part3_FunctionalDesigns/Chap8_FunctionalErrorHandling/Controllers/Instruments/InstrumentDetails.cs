namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.Instruments
{
    public class InstrumentDetails
    {
        public InstrumentDetails(string tickerName, string ticker)
        {
            TickerName = tickerName;
            Ticker = ticker;
        }

        public string TickerName { get; set; }
        public string Ticker { get; set; }
    }
}