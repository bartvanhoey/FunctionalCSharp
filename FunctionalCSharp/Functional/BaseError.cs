namespace FunctionalCSharp.Functional
{
    public abstract class BaseError
    {
        public string Message { get; }

        protected BaseError(string message) => Message = message;
    }
}
