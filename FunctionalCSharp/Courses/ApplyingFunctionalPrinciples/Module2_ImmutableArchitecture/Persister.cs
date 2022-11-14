namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture
{
    public class Persister
    {
        public FileContent ReadFile(string fileName) 
            => new(fileName, File.ReadAllLines(fileName));

        public FileContent[] ReadDirectory(string directoryName) 
            => Directory.GetFiles(directoryName).Select(ReadFile).ToArray();

        public void ApplyChanges(IReadOnlyList<FileAction> fileActions)
        {
            foreach (var action in fileActions)
            {
                switch (action.ActionType)
                {
                    case ActionType.Create:
                    case ActionType.Update:
                        File.WriteAllLines(action.FileName, action.Lines);
                        break;
                    
                    case ActionType.Delete:
                        File.Delete(action.FileName);
                        break;
                    
                    default:
                        throw new InvalidOperationException();
                }
            }
        }
        
        public void ApplyChanges(FileAction fileAction) 
            => ApplyChanges(new List<FileAction> {fileAction});
    }
    
}