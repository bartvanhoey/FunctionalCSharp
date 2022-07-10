using FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.Logic;

namespace FunctionalCSharp.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel
{
    public class Industry : Entity
    {
        public const string CarsIndustry = "Cars";
        public const string PharmacyIndustry = "Pharmacy";

        public string? Name { get; set; }
    }
}
