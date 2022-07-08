using FunctionalCSharp.Exceptions.ResultClass.Errors;
using FunctionalCSharp.Exceptions.ResultClass.Errors.Base;

namespace FunctionalCSharp.Exceptions.ResultClass
{
    public class Result
    {
        protected bool IsSuccess { get; }
        public BaseError? Error { get; }
        public bool IsFailure => !IsSuccess;

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

        public static Result Fail(BaseError error) => new(false, error);

        public static Result<T> Fail<T>(BaseError? error) => new(default, false, error);

        public static Result Ok() => new(true, null);

        public static Result<T> Ok<T>(T value) => new(value, true, null);
    }


    public class Result<T> : Result
    {
        private readonly T _value;
        public T Type => IsSuccess ? _value : throw new InvalidOperationException();

        protected internal Result(T value, bool isSuccess, BaseError? error)
            : base(isSuccess, error) => _value = value;
    }
}