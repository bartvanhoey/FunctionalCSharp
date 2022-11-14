namespace FunctionalCSharp.Courses.MoreEffectiveLinq.Module4CleanAndReadableCode
{
    public class PlayerAge
    {
        public PlayerAge(string? name, int age)
        {
            Name = name;
            Age = age;
        }

        public string? Name { get; }
        public int Age { get; }
    }
}