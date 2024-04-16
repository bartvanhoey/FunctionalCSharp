using FunctionalCSharp.MyYumba;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.FunctionalDomainModelling;

public interface IRepositoryC7<T>
{
    YOption<T> Get(Guid id);
    void Save(Guid id, T t);
}