using System.Xml.Linq;
using static System.Xml.Linq.XDocument;
using static FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module2_ExpressYourself.Module2Constants;
using static FunctionalCSharp.Extensions.UsingExtended;

namespace FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module2_ExpressYourself;

public static class ConvertingStatementsToExpressions
{
    public  static async Task<string?> GetTotalPages_NonFunctional()
    {
        XDocument xDocument;
        using (var client = new HttpClient())
        {
            var photosJson = await client.GetStringAsync(JsonPlaceholderPhotos);
            var photosXml = JsonToXmlHelper.JsonToXml(photosJson);
            xDocument = Parse(photosXml);
        }

        var totalPages = xDocument.Root?.Element("total_pages")?.Value;
        return totalPages;
    }
        
    public static async Task<string?> GetTotalPages_Functional() => (await await UsingAsync(() => new HttpClient(),
            async client => Parse(await client.GetStringAsync(JsonPlaceholderPhotos)))).GetTotalPages();
}