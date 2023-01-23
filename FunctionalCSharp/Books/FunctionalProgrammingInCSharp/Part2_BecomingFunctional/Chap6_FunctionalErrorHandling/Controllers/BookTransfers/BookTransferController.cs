using System.Runtime.InteropServices.JavaScript;
using System.Text.RegularExpressions;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.BookTransfers.Errors;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.Infrastructure;
using LaYumba.Functional;
using Unit = System.ValueTuple;
using static LaYumba.Functional.F;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_BecomingFunctional.Chap6_FunctionalErrorHandling.Controllers.BookTransfers;

public partial class Chapter06BookTransferController : Chapter06ControllerBase
{
    private readonly IHandler<BookTransfer> _transfers;

    public Chapter06BookTransferController() => _transfers = new BookTransferHandler<BookTransfer>();

    public IActionResult BookTransfer(BookTransfer bookTransfer)
        => _transfers.Handle(bookTransfer).Match<IActionResult>(
             BadRequest, x => Ok());


    public ResultDto<Unit> BookTransfer1(BookTransfer bookTransfer) => _transfers.Handle(bookTransfer).ToResultDto();
    
    public Either<BaseError, Unit> Handle(BookTransfer bookTransfer)
        => Right(bookTransfer).Bind(ValidateBic).Bind(ValidateDate).Bind(SaveBook);
    
    private Either<BaseError, Unit> SaveBook(BookTransfer bookTransfer)
    {
        Console.WriteLine("booktransfer saved");
        return default;
    }

    private Validation<BookTransfer> ValidateDateBookTransfer(BookTransfer bookTransfer) 
        => bookTransfer.TransferDate.Date <= DateTime.Now.Date ? Invalid(TransferDateInPastBaseError) : Valid(bookTransfer);

    public Error[] TransferDateInPastBaseError { get; set; }


    private Either<BaseError, BookTransfer> ValidateBic(BookTransfer bookTransfer) => BicRegex().IsMatch(bookTransfer.Bic) ? bookTransfer : Chap06BaseErrors.InvalidBic;
    private Either<BaseError, BookTransfer> ValidateDate(BookTransfer bookTransfer) => bookTransfer.TransferDate > DateTime.Now ? bookTransfer : Chap06BaseErrors.TransferDateIsInPastBaseError;

    [GeneratedRegex("[A-Z]{11}")] private static partial Regex BicRegex();
}