using Fupr.Functional.ResultClass.Errors;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module3_ExceptionsRefactorAway.After.ResultErrors;

public class TicketsOnThisDateNoLongerAvailableResultError : BaseResultError
{
    public TicketsOnThisDateNoLongerAvailableResultError() : base("Tickets on this date are no longer available")
    {
    }
}