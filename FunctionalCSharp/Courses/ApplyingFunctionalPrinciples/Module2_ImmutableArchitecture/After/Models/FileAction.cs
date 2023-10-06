namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Models
{
    public class FileAction
    {
        public string FileName { get; }
        public ActionType ActionType { get; }
        public string[] Lines { get; }

        public FileAction(string fileName, ActionType actionType, string[] lines)
        {
            FileName = fileName;
            ActionType = actionType;
            Lines = lines;
        }
    }
}