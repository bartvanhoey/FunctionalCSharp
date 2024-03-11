using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Linq;
using System.Xml.Serialization;
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
                var photosJson = await client.GetStringAsync(JsonPlaceholderPhotos);
                var photosXml = JsonToXmlHelper.JsonToXml(photosJson);
                xDocument = Parse(photosXml);
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

public static class JsonToXmlHelper
{
    public static string JsonToXml(string json)
    {
        var obj = JsonSerializer.Deserialize<PhotoObject[]>(json)!;

        return ObjectToXml(obj);
    }

    static string ObjectToXml<T>(T obj)
    {
        var xmlSerializer = new XmlSerializer(typeof(T));

        var sb = new StringBuilder();
        using var xmlWriter = XmlWriter.Create(sb);

        var ns = new XmlSerializerNamespaces(new[] { XmlQualifiedName.Empty });
        xmlSerializer.Serialize(xmlWriter, obj, ns);

        return sb.ToString();
    }
}

public class PhotoObject
{
    public int albumId { get; set; }
    public int id { get; set; }
    public string title { get; set; }
    public string url { get; set; }
    public string thumbnailUrl { get; set; }
}