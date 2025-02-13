using FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Models;
using static System.IO.Directory;
using static System.IO.File;

namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After;

public class Persister
{
    public FileContent ReadFile(string fileName) => new(fileName, ReadAllLines(fileName));

    public FileContent[] ReadDirectory(string directoryName) => GetFiles(directoryName).Select(ReadFile).ToArray();

    public void ApplyChange(FileAction fileAction) 
        => ApplyChanges(new List<FileAction> {fileAction});

    public void ApplyChanges(IReadOnlyList<FileAction>? fileActions)
    {
        if (fileActions == null) return;
        foreach (var action in fileActions)
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
}