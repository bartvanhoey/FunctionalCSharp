using System.Text;
using System.Text.Json;
using System.Xml;
using System.Xml.Serialization;

namespace FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module2_ExpressYourself;
public static class JsonToXmlHelper
{
    public static string JsonToXml(string json) => ObjectToXml(JsonSerializer.Deserialize<PhotoObject[]>(json)!);

    private static string ObjectToXml<T>(T obj)
    {
        var xmlSerializer = new XmlSerializer(typeof(T));

        var sb = new StringBuilder();
        using var xmlWriter = XmlWriter.Create(sb);

        var ns = new XmlSerializerNamespaces([XmlQualifiedName.Empty]);
        xmlSerializer.Serialize(xmlWriter, obj, ns);

        return sb.ToString();
    }
}