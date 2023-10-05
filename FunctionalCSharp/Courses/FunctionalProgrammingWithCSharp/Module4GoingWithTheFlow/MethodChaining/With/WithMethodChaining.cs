using System.Text;
using FunctionalCSharp.Extensions;
using static System.Environment;
using static System.StringSplitOptions;
using static System.Text.Encoding;
using static FunctionalCSharp.Extensions.UsingExtended;
using static FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module4GoingWithTheFlow.MethodChaining.StreamFactory;

namespace FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module4GoingWithTheFlow.MethodChaining.With
{
    public static class WithMethodChaining
    {
        public static string GetSelectBoxWithMethodChaining() =>
            Using(GetDoctors, s => new byte[s.Length].Tee(b => s.Read(b, 0, (int) s.Length)))
                .Map(UTF8.GetString)
                .Split(new[] {NewLine}, RemoveEmptyEntries)
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
                    .AppendLine("</select>").ToString().Trim();
    }
}