using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.BookTransfers;

public interface IHandler<in T>
{
    Either<Error, ValueTuple>  Handle(T request);
}