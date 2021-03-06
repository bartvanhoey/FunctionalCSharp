// ReSharper disable UnusedAutoPropertyAccessor.Global
namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.AllTogether.TestCase.Controllers.Models
{
    public class CreateCustomerModel
    {
        public string Name { get; set; }
        public string PrimaryEmail { get; set; }
        public string? SecondaryEmail { get; set; }
        public string Industry { get; set; }
    }
}