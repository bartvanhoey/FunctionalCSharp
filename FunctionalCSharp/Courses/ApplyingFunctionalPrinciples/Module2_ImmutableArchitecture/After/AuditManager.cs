using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Extensions;
using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Models;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After;

public class AuditManager
{
    private readonly int _maxEntriesPerFile;

    public AuditManager(int maxEntriesPerFile) => _maxEntriesPerFile = maxEntriesPerFile;

    public FileAction AddRecord(FileContent currentFile, string visitorName, DateTime timeOfVisit)
    {
        var entries = currentFile.GetAuditEntries();
        if (entries.Count < _maxEntriesPerFile)
        {
            entries.Add(new AuditEntry(entries.Count + 1, visitorName, timeOfVisit));
            return new FileAction(currentFile.FileName, ActionType.Update, entries.ConvertToCsv());
        }

        var entry = new AuditEntry(1, visitorName, timeOfVisit);
        return new FileAction(currentFile.GetNewFileName(), ActionType.Create,
            new List<AuditEntry> { entry }.ConvertToCsv());
    }

    public IReadOnlyList<FileAction> RemoveMentionsAbout(string visitorName, FileContent[] directoryFiles) 
        => directoryFiles
            .Select(file => file.RemoveVisitor(visitorName))
            .Where(action => action != null)
            .Select(action => action!)
            .ToList();
}