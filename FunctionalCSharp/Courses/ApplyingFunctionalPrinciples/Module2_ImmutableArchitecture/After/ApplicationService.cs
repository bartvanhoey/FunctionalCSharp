namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After
{
    public class ApplicationService
    {
        private readonly string _directoryName;
        private readonly AuditManager _auditManager;
        private readonly Persister _persister;

        public ApplicationService(string directoryName, AuditManager auditManager, Persister persister)
        {
            _directoryName = directoryName;
            _auditManager = auditManager;
            _persister = persister;
        }

        public void RemoveMentionsAbout(string visitorName)
        {
            var files = _persister.ReadDirectory(_directoryName);
            var actions = _auditManager.RemoveMentionsAbout(visitorName, files);
            _persister.ApplyChanges(actions);
        }

        public void AddRecord(string visitorName, DateTime timeOfVisit)
        {
            var fileInfo = new DirectoryInfo(_directoryName).GetFiles().OrderByDescending(x => x.LastWriteTime).First();
            var file = _persister.ReadFile(fileInfo.Name);
            var action = _auditManager.AddRecord(file, visitorName, timeOfVisit);
            _persister.ApplyChange(action);
        }
    }
}