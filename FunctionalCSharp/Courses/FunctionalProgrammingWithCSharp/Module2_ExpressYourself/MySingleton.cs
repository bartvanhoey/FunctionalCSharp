namespace FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module2ExpressYourself
{
    public sealed class MySingleton
    {
        private static MySingleton? _instance;
        public static MySingleton MySingletonInstance => _instance ??= new(); // ??= is the null-coalescing assignment operator

        public override string ToString() => $"Type Name: {GetType().Name.Split('+')[0]}";
    }
}


