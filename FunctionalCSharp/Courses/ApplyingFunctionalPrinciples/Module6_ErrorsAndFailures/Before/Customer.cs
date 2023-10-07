namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module6_ErrorsAndFailures.Before
{
    public class Customer
    {
        public int Id { get; set; }
        public decimal Balance { get; set; }
        public string BillingInfo { get; set; }
        
        public void AddBalance(decimal amount) => Balance += amount;
    }
}
