namespace FunctionalCSharp.Courses.MakingYourCSharpCodeMoreFunctional.ObjectFilters.MoneyDemo
{
    public static class MoneyEnumerableExtensions
    {
        public static IEnumerable<Money> On(this IEnumerable<Money> moneys, Timestamp time) 
            => moneys.Select(money => money.On(time));

        public static IEnumerable<SpecificMoney> Of(this IEnumerable<Money> moneys, Currency currency) 
            => moneys.Select(money => money.Of(currency));

        public static IEnumerable<(Amount, Money)> Take(this IEnumerable<SpecificMoney> moneys, decimal amount)
        {
            var rest = amount;
            foreach (var money in moneys)
            {
                var current = money.Take(rest);
                yield return current;
                rest -= current.Item1.Value;
            }
        }
    }
}