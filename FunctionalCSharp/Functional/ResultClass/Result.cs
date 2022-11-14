namespace FunctionalCSharp.Functional.ResultClass
{
    public class Result
    {
        public const string? DefaultNoValueExceptionMessage = "DefaultNoValueExceptionMessage";

        protected Result(bool isSuccess, BaseError? error = null)
        {
            switch (isSuccess)
            {
                case true when error != null:
                    throw new InvalidOperationException();
                case false when error is null:
                    throw new InvalidOperationException();
                default:
                    IsSuccess = isSuccess;
                    Error = error;
                    break;
            }
        }

        public bool IsSuccess { get; }
        public BaseError? Error { get; }
        public bool IsFailure => !IsSuccess;

        public static Result Fail(BaseError error) => new(false, error);

        public static Result<T> Fail<T>(BaseError? error) => new(default!, false, error);

        public static Result Ok() => new(true);

        public static Result<T> Ok<T>(T value) => new(value, true, null);

        public static Result Combine(params Result[] results)
        {
            foreach (var result in results)
                if (result.IsFailure)
                    return result;

            return Ok();
        }
    }


    public class Result<T> : Result
    {
        private readonly T _value;

        protected internal Result(T value, bool isSuccess, BaseError? error)
            : base(isSuccess, error) 
            => _value = value;

        public T Type => IsSuccess  ? _value : throw new InvalidOperationException();
    }
}