using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.Controllers.BookTransfers
{
    public class ResultDto<T>
    {
        public bool Succeedded { get; }
        public bool Failed => !Succeedded;
        public T Data { get; }
        public Error Error;

        public ResultDto(T data) { Succeedded = true;  Data = data; }
        public ResultDto(Error error) => Error = error;
    }
}