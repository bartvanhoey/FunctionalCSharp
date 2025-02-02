using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Extensions;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Models;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Models.ActionType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After;

public class AuditManager(int maxEntriesPerFile)
{
    public FileAction AddRecord(FileContent currentFile, string visitorName, DateTime timeOfVisit)
    {
        var entries = currentFile.GetAuditEntries();
        if (entries.Count < maxEntriesPerFile)
        {
            entries.Add(new AuditEntry(entries.Count + 1, visitorName, timeOfVisit));
            return new FileAction(currentFile.FileName, Update, entries.ConvertToCsv());
        }

        return new FileAction(currentFile.GetNewFileName(), Create, new List<AuditEntry> { new(1, visitorName, timeOfVisit) }.ConvertToCsv());
        
    }

    
}