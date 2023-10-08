namespace FunctionalCSharp.Functional.ResultClass
{
    public abstract class BaseResultError
    {
        protected BaseResultError(string message) => Message = message;
        public string Message { get; }
    }

    public class ResultError : BaseResultError
    {
        public ResultError(string message) : base(message)
        {
        }
    }
}