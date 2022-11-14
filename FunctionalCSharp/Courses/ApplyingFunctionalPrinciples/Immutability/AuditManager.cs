using static System.Int32;
using static System.IO.Path;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Immutability
{
    public class AuditManager
    {
        private readonly int _maxEntriesPerFile;
        public AuditManager(int maxEntriesPerFile) => _maxEntriesPerFile = maxEntriesPerFile;

        public IReadOnlyList<FileAction> RemoveMentionsAbout(string visitorName, FileContent[] directoryFiles)
        {
            return directoryFiles.
                Select(file => RemoveMentionsIn(file, visitorName))
                .Where(action => action!= null)
                .Select(action => action!.Value)
                .ToList();
        }

        private FileAction? RemoveMentionsIn(FileContent file, string visitorName)
        {
            var auditEntries = ParseToAuditEntries(file.Content);
            var updateAuditEntries = auditEntries
                .Where(x => x.Visitor != visitorName)
                .Select((entry, index) => new AuditEntry(index + 1, entry.Visitor, entry.TimeOfVisit))
                .ToList();

            if (updateAuditEntries.Count == auditEntries.Count) return null;
            
            
            if (updateAuditEntries.Count == 0)
                return new FileAction(file.FileName, ActionType.Delete, Array.Empty<string>());
            
            var updateContent = GetContent(updateAuditEntries);

            return new FileAction(file.FileName, ActionType.Update, updateContent);
        }

        public FileAction AddRecord(FileContent file, string visitorName, DateTime visitTime)
        {
            var auditEntries = ParseToAuditEntries(file.Content);
            if (auditEntries.Count < _maxEntriesPerFile)
            {
                auditEntries.Add(new AuditEntry(auditEntries.Count + 1, visitorName, visitTime));
                var updateContent = GetContent(auditEntries);
                return new FileAction(file.FileName, ActionType.Update, updateContent);
            }

            var newAuditEntry = new AuditEntry(1, visitorName, visitTime);
            var content = GetContent(new List<AuditEntry> { newAuditEntry });
            var newFileName = GetNewFileName(file.FileName);
            return new FileAction(newFileName, ActionType.Create, content);
        }

        private static string GetNewFileName(string existingFileName)
            => "Audit_" + (Parse(GetFileNameWithoutExtension(existingFileName).Split('_')[1]) + 1) + ".txt";

        private static string[] GetContent(IEnumerable<AuditEntry> auditEntries)
            => auditEntries.Select(entry => entry.Number + ";" + entry.Visitor + ";" + entry.TimeOfVisit).ToArray();

        private List<AuditEntry> ParseToAuditEntries(string[] content) =>
            content.Select(line => line.Split(";"))
                .Select(data => new AuditEntry(Parse(data[0]), data[1], DateTime.Parse(data[2]))).ToList();
    }

    public class AuditEntry
    {
        public int Number { get; }
        public string Visitor { get; }
        public DateTime TimeOfVisit { get; }

        public AuditEntry(int number, string visitor, DateTime timeOfVisit)
        {
            Number = number;
            Visitor = visitor;
            TimeOfVisit = timeOfVisit;
        }
    }

    public struct FileAction
    {
        public string FileName { get; }
        public string[] Content { get; }
        public ActionType Type { get; }

        public FileAction(string fileName, ActionType type, string[] content)
        {
            FileName = fileName;
            Content = content;
            Type = type;
        }
    }

    public enum ActionType
    {
        Create,
        Update,
        Delete
    }

    public class FileContent
    {
        public string FileName { get; }
        public string[] Content { get; }

        public FileContent(string fileName, string[] content)
        {
            FileName = fileName;
            Content = content;
        }
    }
}