using FunctionalCSharp.NullOptionType;

namespace FunctionalCSharp.PrimitiveObsession.TestCase
{
    public interface IDatabase
    {
        void Save(Customer customer);
        Option<Customer> GetById(int id);
    }
}
