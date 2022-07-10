using FunctionalCSharp.ApplyingFunctionalPrinciples.PrimitiveObsession.ValueObjects;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.MaybeType.FodyNullGuard
{
    public class CustomerAllowNull
    {
        public CustomerAllowNull(CustomerName? customerName, Email? email)
        {
            CustomerName = customerName;
            Email = email;
        }

        public CustomerName? CustomerName { get; }
        public Email? Email { get; }
    }
}