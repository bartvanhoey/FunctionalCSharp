using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.Controllers.BookTransfers
{
    public class BookTransferHandler<T> : IHandler<T> where T : IHaveTransferDate



    {
        public   Either<Error, ValueTuple>  Handle(T request)
        {
            throw new NotImplementedException();
        }
    }
}