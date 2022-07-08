using FunctionalCSharp.PrimitiveObsession.ValueObjects;

namespace FunctionalCSharp.NullOptionType.FodyNullGuard
{
    public class CustomerAllowNull
    {
        public CustomerName? CustomerName { get; }
        public Email? Email { get; }

        public CustomerAllowNull(CustomerName? customerName, Email? email)
        {
            CustomerName = customerName;
            Email = email;
        }
    }
}