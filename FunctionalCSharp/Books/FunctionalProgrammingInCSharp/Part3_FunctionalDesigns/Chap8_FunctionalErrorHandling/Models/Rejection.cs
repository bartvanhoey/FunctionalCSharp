namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Models
{
    public class Rejection
    {
        public Rejection(string reason) => Reason = reason;

        public string Reason { get; }
    }
}