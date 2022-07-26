using System.Globalization;

namespace FunctionalCSharp.Courses.MoreEffectiveLinq.Module4CleanAndReadableCode
{
    public static class CleanAndReadableCode
    {
        public static void GetNameAndAgeOfFootballPlayers()
        {
            var players =
                "Jason Puncheon, 26/06/1986; Jos Hooiveld, 22/04/1983; Kelvin Davis, 29/09/1976; Luke Shaw, 12/07/1995; Gaston Ramirez, 02/12/1990; Adam Lallana, 10/05/1988";

            var enumerable = players
                .Split(';')
                .Select(n => n.Split(','))
                .Select(x => new
                {
                    Name = x[0].Trim(),
                    DateOfBirth = DateTime.ParseExact(x[1].Trim(), "d/M/yyyy", CultureInfo.InvariantCulture)
                })
                .OrderByDescending(n => n.DateOfBirth)
                .Select(n =>
                {
                    var today = DateTime.Today;
                    var age = today.Year -n.DateOfBirth.Year;
                    if (n.DateOfBirth.Date > today.AddYears(-age)) age--;
                    return new { n.Name, Age = age };
                });
        }
    }
}