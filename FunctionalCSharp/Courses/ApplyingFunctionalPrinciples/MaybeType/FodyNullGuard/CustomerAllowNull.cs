using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.PrimitiveObsession.ValueObjects;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.MaybeType.FodyNullGuard
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