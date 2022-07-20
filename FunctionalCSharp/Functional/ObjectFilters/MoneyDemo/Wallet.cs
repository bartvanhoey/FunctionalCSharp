namespace FunctionalCSharp.Functional.ObjectFilters.MoneyDemo
{
    public class Wallet
    {
        private IList<Money> Content { get; set; } = new List<Money>();

        public void Add(Money money) => Content.Add(money);

        public Amount Charge(Currency currency, Amount toCharge)
        {
            IEnumerable<Tuple<Amount, Money>> split =
                Content
                    .On(Timestamp.Now)
                    .Of(toCharge.Currency)
                    .Take(toCharge.Value)
                    .ToList();

            Content = split.Select(tuple => tuple.Item2).ToList();

            var total = split.Sum(tuple => tuple.Item1.Value);
            return new Amount(toCharge.Currency, total);
        }
    }
}