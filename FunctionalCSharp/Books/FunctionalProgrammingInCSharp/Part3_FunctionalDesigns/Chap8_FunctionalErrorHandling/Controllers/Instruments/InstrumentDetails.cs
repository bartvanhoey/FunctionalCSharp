namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.Controllers.Instruments
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