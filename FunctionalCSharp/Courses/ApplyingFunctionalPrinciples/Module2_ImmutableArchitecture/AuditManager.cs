using static System.Int32;
using static System.IO.Path;
using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.ActionType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture
{
    public class AuditManager
    {
        private readonly int _maxEntriesPerFile;

        public AuditManager(int maxEntriesPerFile) => _maxEntriesPerFile = maxEntriesPerFile;

        public FileAction AddRecord(FileContent file, string visitorName, DateTime timeOfVisit)
        {
            var entries = file.GetAuditEntries();

            if (entries.Count < _maxEntriesPerFile)
            {
                entries.Add(new AuditEntry(entries.Count+1, visitorName, timeOfVisit));
                var newContent = entries.ToStringArray();
                return new FileAction(file.FileName, newContent, Update);
            }

            entries.Add(new AuditEntry(entries.Count+1, visitorName, timeOfVisit));
            return new FileAction(GetNewFileName(file.FileName), entries.ToStringArray(), Create);
        }

        public IReadOnlyList<FileAction> RemoveMentionsAbout(string visitorName, IEnumerable<FileContent> files) =>
            files
                .Select(file => file.RemoveMentionsIn(visitorName))
                .Where(x => x.HasValue)
                .Select(action => action!.Value)
                .ToList();
        
        private string GetNewFileName(string existingFileName)
        {
            var fileName = GetFileNameWithoutExtension(existingFileName);
            var index = Parse(fileName.Split('_')[1]);
            return "Audit_" + (index + 1) + ".txt";
        }

    }
}