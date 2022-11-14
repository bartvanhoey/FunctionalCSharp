namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture
{
    public class AuditManagerService
    {
        private readonly string _directoryName;
        private readonly AuditManager _auditManager;
        private readonly Persister _persister;

        public AuditManagerService(string directoryName)
            => _directoryName = directoryName;

        public void RemoveMentionsAbout(string visitorName)
        {
            var fileContents = _persister.ReadDirectory(_directoryName);
            var fileActions = _auditManager.RemoveMentionsAbout(visitorName, fileContents);
            _persister.ApplyChanges(fileActions);
        }
        
        public void AddRecord(string visitorName, DateTime timeOfVisit)
        {
            var fileInfo = new DirectoryInfo(_directoryName).GetFiles().OrderByDescending(x => x.LastWriteTime)
                .First();
            
            var fileContent = _persister.ReadFile(fileInfo.Name);
            var fileAction = _auditManager.AddRecord(fileContent, visitorName, timeOfVisit);
            _persister.ApplyChanges(fileAction);
        }
    }
}