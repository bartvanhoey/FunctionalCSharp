using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module4_AvoidPrimitiveObsession.ValueObjects;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module5_AvoidingNullsWithMaybeType.FodyNullGuard
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