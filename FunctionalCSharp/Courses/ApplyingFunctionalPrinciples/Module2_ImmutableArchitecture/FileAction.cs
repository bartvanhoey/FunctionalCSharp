namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture
{
    public struct FileAction
    {
        public FileAction(string fileName, string[] lines, ActionType actionType)
        {
            FileName = fileName;
            Lines = lines;
            ActionType = actionType;
        }

        public readonly string FileName; 
        public readonly string[] Lines; 
        public readonly ActionType ActionType;
    }
}