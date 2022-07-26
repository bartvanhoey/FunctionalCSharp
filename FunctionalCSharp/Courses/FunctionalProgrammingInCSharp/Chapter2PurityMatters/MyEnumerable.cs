namespace FunctionalCSharp.Courses.FunctionalProgrammingInCSharp.Chapter2PurityMatters
{
    public static class MyEnumerable
    {
        public static IEnumerable<string> Zip(IEnumerable<int> ints, IEnumerable<string> strings) 
            => ints.Zip(strings, (number, name) => $"In English, {number} is: {name}");
    }
}