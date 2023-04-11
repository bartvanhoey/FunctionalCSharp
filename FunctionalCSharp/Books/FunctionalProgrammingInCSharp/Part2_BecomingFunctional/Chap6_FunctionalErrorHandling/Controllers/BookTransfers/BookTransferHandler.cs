using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.BookTransfers
{
    public class BookTransferHandler<T> : IHandler<T> where T : IHaveTransferDate



    {
        public   Either<Error, ValueTuple>  Handle(T request)
        {
            throw new NotImplementedException();
        }
    }
}