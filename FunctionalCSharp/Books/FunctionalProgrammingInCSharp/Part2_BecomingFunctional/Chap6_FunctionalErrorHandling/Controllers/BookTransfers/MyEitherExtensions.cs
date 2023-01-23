using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.BookTransfers;

public static class MyEitherExtensions
{
    public static ResultDto<T> ToResultDto<T>(this Either<Error, T> either) 
        => either.Match(error => new ResultDto<T>(error), data => new ResultDto<T>(data));
}