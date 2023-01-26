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
    
    public Either<Error, Unit> Handle1(BookTransfer bookTransfer)
        => Right(bookTransfer).Bind(ValidateBic1).Bind(ValidateDate1).Bind(SaveBook);

    public Validation<Exceptional<Unit>> Handle2(BookTransfer bookTransfer) => Validate(bookTransfer).Map(SaveBookTransfer);
    

    private Validation<BookTransfer> Validate(BookTransfer bookTransfer) => ValidateBic2(bookTransfer).Bind(ValidateDate2);

    private Either<Error, Unit> SaveBook(BookTransfer bookTransfer)
    {
        Console.WriteLine("booktransfer saved");
        return default;
    }

    private Validation<BookTransfer> ValidateDateBookTransfer(BookTransfer bookTransfer) 
        => bookTransfer.TransferDate.Date <= DateTime.Now.Date ? Invalid(Chap06BaseErrors.TransferDateIsInPastBaseError) : Valid(bookTransfer);


    public Exceptional<Unit> SaveBookTransfer(BookTransfer transfer)
    {
        try
        {
            
        }
        catch (Exception exception)
        {
            return exception;
        }

        return Unit();
    }




    private Either<Error, BookTransfer> ValidateBic1(BookTransfer bookTransfer) => BicRegex().IsMatch(bookTransfer.Bic) ? bookTransfer : Chap06BaseErrors.InvalidBic;
    private Validation<BookTransfer> ValidateBic2(BookTransfer bookTransfer) => BicRegex().IsMatch(bookTransfer.Bic) ? bookTransfer : Invalid(Chap06BaseErrors.InvalidBic);
    private Either<Error, BookTransfer> ValidateDate1(BookTransfer bookTransfer) => bookTransfer.TransferDate > DateTime.Now ? bookTransfer : Chap06BaseErrors.TransferDateIsInPastBaseError;
    private Validation<BookTransfer> ValidateDate2(BookTransfer bookTransfer) => bookTransfer.TransferDate > DateTime.Now ? bookTransfer : Chap06BaseErrors.TransferDateIsInPastBaseError;

    [GeneratedRegex("[A-Z]{11}")] private static partial Regex BicRegex();
}

