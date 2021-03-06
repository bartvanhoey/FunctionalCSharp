using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.Logic;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.DomainModel
{
    public class Industry : Entity
    {
        public const string CarsIndustry = "Cars";
        public const string PharmacyIndustry = "Pharmacy";
        public const string OtherIndustry = "Other";

        public string? Name { get; set; }
    }
}