namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.Before
{
    public class Ticket
    {
        public Ticket(DateTime date, string customerName)
        {
            Date = date;
            CustomerName = customerName;
        }

        public DateTime Date { get; }
        public string CustomerName { get; }
    }
}