namespace Exceptions
{
    public class CannotReserveOnAPastDateError : BaseError {
        public CannotReserveOnAPastDateError() : base("cannot reserve on a past date")
        {
        }
    }
}
