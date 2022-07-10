using FunctionalCSharp.NullOptionType;

namespace FunctionalCSharp.PrimitiveObsession.TestCase
{
    public interface IDatabase
    {
        void Save(Customer customer);
        Maybe<Customer> GetById(int id);
    }
}
