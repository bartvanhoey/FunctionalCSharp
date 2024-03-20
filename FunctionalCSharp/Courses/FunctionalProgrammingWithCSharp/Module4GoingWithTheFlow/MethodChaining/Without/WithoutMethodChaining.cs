using System.Text;

namespace FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module4GoingWithTheFlow.MethodChaining.Without;

public static class WithoutMethodChaining
{
    public static string GetSelectBoxWithoutMethodChaining()
    {
        byte[] buffer;

        using (var stream = StreamFactory.GetDoctors())
        {
            buffer = new byte[stream.Length];
            // ReSharper disable once MustUseReturnValue
            stream.Read(buffer, 0, (int)stream.Length);
        }

        var options =
            Encoding
                .UTF8
                .GetString(buffer)
                .Split(new[] { Environment.NewLine, }, StringSplitOptions.RemoveEmptyEntries)
                .Select((s, ix) => Tuple.Create(ix, s))
                .ToDictionary(k => k.Item1, v => v.Item2);

        var selectBox = BuildSelectBox(options, "theDoctors", true);

        Console.WriteLine(selectBox);
            
        return selectBox;
    }

    private static string BuildSelectBox(IDictionary<int, string> options, string id, bool includeUnknown)
    {
        var html = new StringBuilder();
        html.AppendFormat("<select id=\"{0}\" name=\"{0}\">", id);
        html.AppendLine();

        if (includeUnknown)
        {
            html.AppendLine("\t<option>Unknown</option>");
        }

        foreach (var opt in options)
        {
            html.AppendFormat("\t<option value=\"{0}\">{1}</option>", opt.Key, opt.Value);
            html.AppendLine();
        }

        html.AppendLine("</select>");

        return html.ToString().Trim();
    }
}