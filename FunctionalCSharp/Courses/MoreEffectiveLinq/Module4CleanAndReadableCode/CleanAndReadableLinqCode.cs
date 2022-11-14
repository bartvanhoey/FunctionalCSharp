using static System.DateTime;
using static System.Globalization.CultureInfo;

namespace FunctionalCSharp.Courses.MoreEffectiveLinq.Module4CleanAndReadableCode
{
    public static class CleanAndReadableLinqCode
    {
        public static IEnumerable<PlayerAge> GetPlayerAge(string players) =>
            players
                .Split(';')
                .Select(n => n.Split(','))
                .Select(x => new
                {
                    Name = x[0].Trim(),
                    DateOfBirth = ParsDob(x[1])
                })
                .OrderByDescending(n => n.DateOfBirth)
                .Select(n =>
                {
                    var age = n.DateOfBirth.CalculateAge();
                    return new PlayerAge(n.Name, age);
                });

        private static DateTime ParsDob(string dob) => ParseExact(dob.Trim(), "d/M/yyyy", InvariantCulture);
    }
}