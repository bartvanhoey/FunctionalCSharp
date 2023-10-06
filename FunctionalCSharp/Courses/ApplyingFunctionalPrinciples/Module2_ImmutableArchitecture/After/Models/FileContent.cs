namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture.After.Models
{
    public class FileContent
    {
        public string FileName { get; }
        public string[] Content { get; }

        public FileContent(string fileName, string[] content)
        {
            FileName = fileName;
            Content = content;
        }
    }
}