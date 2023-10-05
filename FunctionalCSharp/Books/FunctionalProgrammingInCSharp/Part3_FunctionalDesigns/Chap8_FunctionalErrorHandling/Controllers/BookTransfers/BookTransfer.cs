namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part3_FunctionalDesigns.Chap8_FunctionalErrorHandling.Controllers.BookTransfers
{
    public class BookTransfer : IHaveTransferDate
    {
        public BookTransfer(string bic, DateTime transferDate)
        {
            Bic = bic;
            TransferDate = transferDate;
        }

        public string Bic { get; set; }
        public DateTime TransferDate { get; set; }

    }
}