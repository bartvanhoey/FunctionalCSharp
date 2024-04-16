using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.BankOfCodeland;
using FunctionalCSharp.MyYumba;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.FunctionalDomainModelling;

public class MakeTransferControllerEndToEnd(IValidatorC7<MakeTransferC7> validatorC7, IRepositoryC7<AccountState> accountRepo, ISwiftServiceC7 swiftServiceC7)
    : ControllerBaseC7
{

    public void MakeTransfer(MakeTransferC7 transfer)
        => Y.YSome(transfer).YMap(MakeTransferC7Extensions.CapitalizeBeneficiary).YWhere(validatorC7.IsValid)
            .YForEach(Book);

    private void Book(MakeTransferC7 transfer)
    {
        accountRepo.Get(transfer.DebitedAccountId).YBind(a => a.Debit(transfer.Amount))
            .YForEach(accountState =>
            {
                accountRepo.Save(transfer.DebitedAccountId, accountState);
                swiftServiceC7.Wire(transfer, accountState);
            });
    }
}