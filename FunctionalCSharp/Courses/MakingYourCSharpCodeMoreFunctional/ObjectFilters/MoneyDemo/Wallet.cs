namespace FunctionalCSharp.Courses.MakingYourCSharpCodeMoreFunctional.ObjectFilters.MoneyDemo
{
    public class Wallet
    {
        private IList<Money> Content { get; set; } = new List<Money>();

        public void Add(Money money) => Content.Add(money);

        public Amount Charge(Currency currency, Amount toCharge)
        {
            IEnumerable<(Amount taken, Money remaining)> split =
                Content
                    .On(Timestamp.Now)
                    .Of(toCharge.Currency)
                    .Take(toCharge.Value)
                    .ToList();

            Content = split.Select(tuple => tuple.remaining).ToList();

            var total = split.Sum(tuple => tuple.taken.Value);
            
            return new Amount(toCharge.Currency, total);
        }
    }
}