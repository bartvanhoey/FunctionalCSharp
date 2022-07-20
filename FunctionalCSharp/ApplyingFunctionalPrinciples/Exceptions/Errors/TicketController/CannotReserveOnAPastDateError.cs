using FunctionalCSharp.Functional.ResultType;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.Exceptions.Errors.TicketController
{
    public class CannotReserveOnAPastDateError : BaseError
    {
        public CannotReserveOnAPastDateError() : base("cannot reserve on a past date")
        {
        }
    }
}