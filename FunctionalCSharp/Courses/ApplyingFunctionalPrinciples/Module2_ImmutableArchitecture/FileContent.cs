namespace FunctionalCSharp.Courses.ApplyingFunctionalPrinciples.Module2_ImmutableArchitecture
{
    public struct FileContent
    {
        public FileContent(string fileName, string[] lines)
        {
            FileName = fileName;
            Lines = lines;
        }

        public readonly string FileName;
        public readonly string[] Lines;
    }
}