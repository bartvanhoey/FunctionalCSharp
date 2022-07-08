using FunctionalCSharp.Exceptions.ResultClass.Errors.Base;

namespace FunctionalCSharp.Exceptions.ResultClass.Errors.TicketController
{
    public class CannotReserveOnAPastDateError : BaseError {
        public CannotReserveOnAPastDateError() : base("cannot reserve on a past date")
        {
        }
    }
}
