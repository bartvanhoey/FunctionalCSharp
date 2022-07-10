namespace FunctionalCSharp.Functional
{
    public abstract class BaseError
    {
        protected BaseError(string message)
        {
            Message = message;
        }

        public string Message { get; }
    }
}