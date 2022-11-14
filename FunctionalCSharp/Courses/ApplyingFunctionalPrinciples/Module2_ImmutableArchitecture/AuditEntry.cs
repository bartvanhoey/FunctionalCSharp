namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture
{
    public struct AuditEntry
    {
        public readonly int Number;
        public readonly string VisitorName;
        public readonly DateTime TimeOfVisit;

        public AuditEntry(int number, string visitorName, DateTime timeOfVisit)
        {
            Number = number;
            VisitorName = visitorName;
            TimeOfVisit = timeOfVisit;
        }
    }
}