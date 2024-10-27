using System.Xml.Linq;

namespace FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module2_ExpressYourself;

public static class XDocumentExtensions {


    public static string? GetTotalPages(this XDocument xDocument) => xDocument.Root?.Element("totalPages")?.Value;
}