using System.Xml.Linq;
using static System.Xml.Linq.XDocument;
using static FunctionalCSharp.Extensions.UsingExtended;

namespace FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module2ExpressYourself
{
    public static class ConvertingStatementsToExpressions
    {
        private const string TravelApiUrl = @"http://restapi.adequateshop.com/api/Traveler";

        public  static async Task<string?> GetTotalPages_NonFunctional()
        {
            XDocument xDocument;
            using (var client = new HttpClient())
            {
                xDocument = Parse(await client.GetStringAsync(TravelApiUrl));
            }

            var totalPages = xDocument.Root?.Element("total_pages")?.Value;
            return totalPages;
        }
        
        public  static async Task<string?> GetTotalPages_Functional() =>
            (await await UsingAsync(
                () => new HttpClient(),
                async client => Parse(await client.GetStringAsync(TravelApiUrl))))
            .Root?.Element("total_pages")?.Value;
    }
}