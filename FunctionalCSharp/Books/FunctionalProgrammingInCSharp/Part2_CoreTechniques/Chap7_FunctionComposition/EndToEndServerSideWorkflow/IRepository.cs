using LaYumba.Functional;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part2_CoreTechniques.Chap7_FunctionComposition.EndToEndServerSideWorkflow
{
    public interface IRepository<T>
    {
        Option<T> Get(Guid id);
        void Save(Guid id, T t);
    }
}