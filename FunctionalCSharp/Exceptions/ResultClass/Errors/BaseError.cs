namespace FunctionalCSharp.Exceptions.ResultClass.Errors
{
    public abstract class BaseError
    {
        public string? Message { get; }

        protected BaseError(string? message) => Message = message ?? throw new ArgumentNullException(nameof(message));
    }
}
