using System.Xml.Linq;
using static System.Xml.Linq.XDocument;
using static FunctionalCSharp.Extensions.UsingExtended;

namespace FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module2_ExpressYourself
{
    public static class ConvertingStatementsToExpressions
    {
        private const string JsonPlaceholderPhotos = @"https://jsonplaceholder.typicode.com/photos";

        public  static async Task<string?> GetTotalPages_NonFunctional()
        {
            XDocument xDocument;
            using (var client = new HttpClient())
            {
                xDocument = Parse(await client.GetStringAsync(JsonPlaceholderPhotos));
            }

            var totalPages = xDocument.Root?.Element("total_pages")?.Value;
            return totalPages;
        }
        
        public  static async Task<string?> GetTotalPages_Functional() =>
            (await await UsingAsync(
                () => new HttpClient(),
                async client => Parse(await client.GetStringAsync(JsonPlaceholderPhotos))))
            .Root?.Element("total_pages")?.Value;
    }
}