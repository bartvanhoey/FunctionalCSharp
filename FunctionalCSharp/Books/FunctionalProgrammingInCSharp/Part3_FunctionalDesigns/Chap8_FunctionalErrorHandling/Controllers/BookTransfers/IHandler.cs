using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.Controllers.BookTransfers
{
    public interface IHandler<in T>
    {
        Either<Error, ValueTuple>  Handle(T request);
    }
}