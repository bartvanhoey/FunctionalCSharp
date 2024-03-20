using FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.FunctionalDomainModelling;
using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.EndToEndServerSideWorkflow;

public class AccountStateRepository : IRepository<AccountStateC7>
{
    public Option<AccountStateC7> Get(Guid id) => new Random().Next(1,11) > 5 ? new AccountStateC7(100) : F.None;

    public void Save(Guid id, AccountStateC7 t)
    {
        Console.WriteLine("saved");
    }
}