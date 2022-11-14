namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures
{
    public class Customer
    {
        public int Id { get; set; }
        public decimal Balance { get; private set; }
        public string BillingInfo { get; set; }
        
        public void AddBalance(MoneyToCharge amount) => Balance += amount;
    }
}
