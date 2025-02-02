using CSharpFunctionalExtensions;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After;

public class TheaterGateway
{
    public Result Reserve(DateTime date, string customerName)
    {
        try
        {
            var client = new TheaterApiClient();
            client.Reserve(date, customerName);
        }
        catch (HttpRequestException)
        {
            return Result.Failure("Theater is currently unavailable");
        }
        catch (InvalidOperationException)
        {
            return Result.Failure("Tickets not available");
        }

        return Result.Success();
    }
}