// namespace FunctionalCSharp.Functional.ResultClass
// {
//     public class Result
//     {
//         public const string? DefaultNoValueExceptionMessage = "DefaultNoValueExceptionMessage";
//
//         protected Result(bool isSuccess, BaseResultError? error = null)
//         {
//             switch (isSuccess)
//             {
//                 case true when error != null:
//                     throw new InvalidOperationException();
//                 case false when error is null:
//                     throw new InvalidOperationException();
//                 default:
//                     IsSuccess = isSuccess;
//                     Error = error;
//                     break;
//             }
//         }
//
//         public bool IsSuccess { get; }
//         public BaseResultError? Error { get; }
//         public bool IsFailure => !IsSuccess;
//
//         public static Result Fail(BaseResultError resultError) => new(false, resultError);
//
//         public static Result<T> Failure<T>(BaseResultError? resultError) => new(default!, false, resultError);
//
//         public static Result Ok() => new(true);
//
//         public static Result<T> Ok<T>(T value) => new(value, true, null);
//
//         public static Result Combine(params Result[] results)
//         {
//             foreach (var result in results)
//                 if (result.IsFailure)
//                     return result;
//
//             return Ok();
//         }
//     }
//
//
//     public class Result<T> : Result
//     {
//         private readonly T _value;
//
//         protected internal Result(T value, bool isSuccess, BaseResultError? error)
//             : base(isSuccess, error) 
//             => _value = value;
//
//         public T Value => IsSuccess  ? _value : throw new InvalidOperationException();
//     }
// }