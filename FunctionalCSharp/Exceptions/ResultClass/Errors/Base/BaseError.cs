namespace FunctionalCSharp.Exceptions.ResultClass.Errors.Base
{
    public abstract class BaseError
    {
        public string Message { get; }

        protected BaseError(string message) => Message = message;
    }
}
