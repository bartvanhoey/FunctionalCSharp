namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Models;

public class FileAction
{
    public string FileName { get; }
    public ActionType Type { get; }
    public string[] Content { get; }

    public FileAction(string fileName, ActionType type, string[] content)
    {
        FileName = fileName;
        Type = type;
        Content = content;
    }
}