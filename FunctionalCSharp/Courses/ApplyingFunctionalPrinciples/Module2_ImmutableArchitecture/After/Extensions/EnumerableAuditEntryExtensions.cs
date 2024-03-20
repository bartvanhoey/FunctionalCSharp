using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Models;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Extensions;

public static class EnumerableAuditEntryExtensions
{
    public static string[] ConvertToCsv(this IEnumerable<AuditEntry> auditEntries) =>
        auditEntries
            .Select(entry => $"{entry.Number};{entry.VisitorName};{entry.TimeOfVisit:s}")
            .ToArray();
}