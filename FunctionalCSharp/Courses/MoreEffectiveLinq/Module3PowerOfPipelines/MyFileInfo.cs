namespace FunctionalCSharp.Courses.MoreEffectiveLinq.Module3PowerOfPipelines
{
    public class MyFileInfo
    {
        public MyFileInfo(string? file, string? text, int lineNumber)
        {
            File = file;
            Text = text;
            LineNumber = lineNumber;
        }

        public string? File { get; set; }
        public string? Text { get; set; }
        public int LineNumber { get; set; }
    }
}