namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_Exceptions.TestCase
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