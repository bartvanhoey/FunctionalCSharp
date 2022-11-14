using System.Text;
using FunctionalCSharp.Extensions;
using static FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module2ExpressYourself.DisposableUsing;

namespace FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module4GoingWithTheFlow.MethodChaining.With
{
    public static class WithMethodChaining
    {
        public static string GetSelectBoxWithMethodChaining() =>
            Using(StreamFactory.GetStream,
                    stream => new byte[stream.Length].Tee(b => stream.Read(b, 0, (int) stream.Length)))
                .Map(Encoding.UTF8.GetString)
                .Split(new[] {Environment.NewLine}, StringSplitOptions.RemoveEmptyEntries)
                .Select((s, ix) => Tuple.Create(ix, s))
                .ToDictionary(k => k.Item1, v => v.Item2)
                .Map(BuildSelectBox("theDoctors", true))
                .Tee(Console.WriteLine);
        
        private static Func<IDictionary<int, string>, string> BuildSelectBox(string id, bool includeUnknown) =>
            options =>
                new StringBuilder()
                    .AppendFormattedLine("<select id=\"{0}\" name=\"{0}\">", id)
                    .AppendWhen(() => includeUnknown, sb => sb.AppendLine("\t<option>Unknown</option>"))
                    .AppendSequence(options,
                        (sb, opt) => sb.AppendFormattedLine("\t<option value=\"{0}\">{1}</option>", opt.Key, opt.Value))
                    .AppendLine("</select>")
                    .ToString().Trim();
    }
}