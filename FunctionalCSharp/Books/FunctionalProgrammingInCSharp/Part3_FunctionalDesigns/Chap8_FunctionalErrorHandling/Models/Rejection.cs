namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.Models;

public class Rejection
{
    public Rejection(string reason) => Reason = reason;

    public string Reason { get; }
}