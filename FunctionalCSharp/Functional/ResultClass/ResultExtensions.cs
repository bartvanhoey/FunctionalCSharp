using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures;
using FunctionalCSharp.Functional.MaybeClass;
using static FunctionalCSharp.Functional.ResultClass.Result;

namespace FunctionalCSharp.Functional.ResultClass
{
    public static class ResultExtensions
    {
        public static Result<T> ToResult<T>(this Maybe<T> maybe, BaseResultError resultError) where T : class 
            => maybe.HasNoValue ? Fail<T>(resultError) : Ok(maybe.Type);

        public static Result OnSuccess(this Result result, Action action)
        {
            if (result.IsFailure)
                return result;

            action();

            return Ok();
        }
        
        public static Result<T> OnSuccess<T>(this Result<T> result, Action<T> action)
        {
            if (result.IsSuccess) action(result.Type);
            return result;
        }

        public static Result<TK> OnSuccess<T,TK>(this Result<T> result, Func<T,TK> func) 
            => result.IsFailure ? Fail<TK>(result.Error) : Ok(func(result.Type));


        public static Result OnSuccess(this Result result, Func<Result> func) 
            => result.IsFailure ? result : func();

        public static Result OnFailure(this Result result, Action action)
        {
            if (result.IsFailure) action();
            return result;
        }

        public static Result OnBoth(this Result result, Action<Result> action)
        {
            action(result);
            return result;
        }

        public static T OnBoth<T>(this Result result, Func<Result, T> func) 
            => func(result);
        
        public static void LogResult(this Result result, Logger logger)
            => logger.Log(result.IsFailure ? result.Error?.Message! : "OK");
        
        public static Result<R> Map<T, R>(this Result<T> result, Func<T, R> func) 
            => result.IsFailure ? Fail<R>(result.Error) : Ok(func(result.Type));
        
        public static Result<T> Ensure<T>(this Result<T> result, Func<T, bool> func, BaseResultError baseResultError)
        {
            if (result.IsFailure) return result;
            return func(result.Type) ? result : Fail<T>(baseResultError);
        }

        
    }
}