using static FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.ActionType;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture
{
    public static class AuditManagerExtensions
    {

        public static string[] ToStringArray(this IEnumerable<AuditEntry> entries) 
            => entries.Select(entry => entry.Number + ";" + entry.VisitorName + ";" + entry.TimeOfVisit.ToString("s")).ToArray();
        
        public static FileAction? RemoveMentionsIn(this FileContent file, string visitorName)
        {
            var auditEntries = GetAuditEntries(file);
            var newContent = auditEntries.Where(x => x.VisitorName != visitorName).Select((entry, index) =>
                new AuditEntry(index + 1, entry.VisitorName, entry.TimeOfVisit)).ToList().ToStringArray();
            if (auditEntries.Count == newContent.Length) return null;
            return newContent.Length== 0 ? new FileAction(file.FileName, Array.Empty<string>(), Delete) : new FileAction(file.FileName, newContent, Update);
        }

        public static List<AuditEntry> GetAuditEntries(this FileContent file) =>
            file.Lines.Select(line => line.Split(';'))
                .Select(data => new AuditEntry(int.Parse(data[0]), data[1], DateTime.Parse(data[2]))).ToList();
    }
}