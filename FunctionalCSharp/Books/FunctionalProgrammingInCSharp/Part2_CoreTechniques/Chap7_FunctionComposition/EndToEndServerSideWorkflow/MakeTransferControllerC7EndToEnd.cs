using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.BankOfCodeland;
using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.FunctionalDomainModelling;
using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.EndToEndServerSideWorkflow;

public class MakeTransferControllerC7EndToEnd : ControllerBaseC7
{
    private readonly IValidatorC7<MakeTransferC7> _validatorC7;
    private readonly IRepository<AccountStateC7> _accountStateRepo;
    private readonly ISwiftService _swiftService;

    public MakeTransferControllerC7EndToEnd(ISwiftService swiftService, IRepository<AccountStateC7> accountStateRepo, IValidatorC7<MakeTransferC7> validatorC7)
    {
        _swiftService = new SwiftService();
        _accountStateRepo = new AccountStateRepository();
        _validatorC7 = new BicFormatValidatorC7();
    }

    public void MakeTransfer(MakeTransferC7 makeTransferC7) =>
        F.Some(makeTransferC7)
            .Map(x => x.CapitalizeBeneficiary())
            .Where(_validatorC7.IsValid)
            .ForEach(Book);

    private void Book(MakeTransferC7 transfer) =>
        _accountStateRepo
            .Get(transfer.DebitedAccountId)
            .Bind(accountState => accountState.Debit(transfer.Amount))
            .ForEach(accountState =>
            {
                _accountStateRepo.Save(transfer.DebitedAccountId, accountState);
                _swiftService.Wire(transfer, accountState);
            });
}