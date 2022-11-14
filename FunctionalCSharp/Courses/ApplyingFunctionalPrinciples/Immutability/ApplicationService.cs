namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Immutability
{
    public class ApplicationService
    {
        private readonly string _directoryName;
        private readonly AuditManager _auditManager;
        private readonly Persister _persister;

        public ApplicationService(string directoryName)
        {
            _directoryName = directoryName;
            _auditManager = new AuditManager(10);
            _persister = new Persister();
        }

        public void RemoveMentionsAbout(string visitorName)
        {
            var files = _persister.ReadDirectory(_directoryName);
            var actions = _auditManager.RemoveMentionsAbout(visitorName, files);
            _persister.ApplyChanges(actions);
        }

        public void AddRecord(string visitorName, DateTime timeOfVisit)
        {
            var fileInfo = new DirectoryInfo(_directoryName)
                .GetFiles()
                .OrderByDescending(x => x.LastWriteTime)
                .First();

            var file = _persister.ReadFile(fileInfo.Name);
            var action = _auditManager.AddRecord(file, visitorName, timeOfVisit);
            _persister.ApplyChange(action);
        }
    }
}