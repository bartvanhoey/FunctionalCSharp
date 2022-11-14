using static System.IO.Directory;
using static System.IO.File;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Immutability
{
    public class Persister
    {
        public FileContent ReadFile(string fileName) 
            => new(fileName, ReadAllLines(fileName));

        public FileContent[] ReadDirectory(string directoryName) =>
            GetFiles(directoryName)
                .Select(ReadFile)
                .ToArray();

        public  void ApplyChanges(IEnumerable<FileAction> actions)
        {
            foreach (var action in actions)
            {
                switch (action.Type)
                {
                    case ActionType.Create:
                    case ActionType.Update:
                        WriteAllLines(action.FileName, action.Content);
                        continue;

                    case ActionType.Delete:
                        File.Delete(action.FileName);
                        continue;

                    default:
                        throw new InvalidOperationException();
                }
            }
        }

        public void ApplyChange(FileAction action) 
            => ApplyChanges(new List<FileAction> { action });
    }
}