namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.Before;

public class TheaterGateway
{
    public void Reserve(DateTime date, string customerName)
    {
        var client = new TheaterApiClient();
        client.Reserve(date,customerName);
    }
}