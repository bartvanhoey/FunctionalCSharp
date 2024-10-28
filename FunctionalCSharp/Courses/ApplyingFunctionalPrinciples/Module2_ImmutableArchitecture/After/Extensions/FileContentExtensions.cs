using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Models;
using static System.Array;
using static System.Int32;
using static System.IO.Path;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Extensions;

public static class FileContentExtensions
{
    public static List<AuditEntry> GetAuditEntries(this FileContent fileContent)
        => fileContent.Content.Select(line => line.Split(';'))
            .Select(data => new AuditEntry(Parse(data[0]), data[1], DateTime.Parse(data[2]))).ToList();


    public static string GetNewFileName(this FileContent fileContent)
        => "Audit_" + (Parse(GetFileNameWithoutExtension(fileContent.FileName).Split('_')[1]) + 1) + ".txt";

    public static FileAction? RemoveVisitor(this FileContent fileContent, string visitorName)
    {
        var auditEntries = fileContent.GetAuditEntries();
        var newContent = auditEntries
            .Where(x => x.VisitorName != visitorName)
            .Select((x, i) => new AuditEntry(i + 1, x.VisitorName, x.TimeOfVisit))
            .ToList();

        if (newContent.Count == auditEntries.Count) return default;
            
        if (newContent.Count==0)
            return new FileAction(fileContent.FileName, ActionType.Delete, Empty<string>());


        return new FileAction(fileContent.FileName, ActionType.Update, newContent.ConvertToCsv());
    }
    
    public static IReadOnlyList<FileAction> RemoveMentionsAbout(this FileContent[] fileContents, string visitorName) 
        => fileContents
            .Select(file => file.RemoveVisitor(visitorName))
            .Where(action => action != null)
            .Select(action => action!)
            .ToList();
}