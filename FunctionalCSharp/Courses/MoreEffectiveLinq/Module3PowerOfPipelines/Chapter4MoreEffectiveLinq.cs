using static System.IO.Directory;
using static System.IO.File;
using static System.Text.RegularExpressions.Regex;

namespace FunctionalCSharp.Courses.MoreEffectiveLinq.Module3PowerOfPipelines;

public static class Chapter4MoreEffectiveLinq
{
    private static string GetFilePath() => Path
        .Combine(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location)!,
            "MoreEffectiveLinq", "Module3PowerOfPipelines").Replace(".Tests", "");

    public static IEnumerable<YileInfo> SearchInCsvFile(string searchTerm, string fileType)
    {
        return EnumerateFiles(GetFilePath(), fileType)
            .SelectMany(file =>
                ReadAllLines(file).Select((line, index) => new YileInfo(file, line, index + 1)))
            .Where(line => IsMatch(line.Text ?? string.Empty, searchTerm)).ToList();
    }

    public static IEnumerable<string> GetDistinctLicenseNamesFromCsvFile() =>
        EnumerateFiles(GetFilePath(), "*.csv")
            .SelectMany(file => ReadAllLines(file)
                .Skip(1)
                .Select(line => line.Split(','))
                .Where(parts => parts.Length > 2))
            .Where(parts => IsMatch(parts[3], "qemu"))
            .Select(parts => new
            {
                ExternalLibraryName = parts[0],
                LicenseName = parts[2]
            })
            .Where(x => x.LicenseName.Length >= 3)
            .Select(e => e.LicenseName)
            .Distinct()
            .ToList();
}