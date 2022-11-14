namespace FunctionalCSharp.Courses.MakingYourCSharpCodeMoreFunctional.ObjectFilters.MoneyDemo
{
    public abstract class Money
    {
        public abstract Money On(Timestamp time);
        public abstract SpecificMoney Of(Currency currency);
    }
}