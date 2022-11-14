namespace FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module2ExpressYourself
{
    public sealed class MySingleton
    {
        private static MySingleton? _instance;
        public static MySingleton MySingletonInstance => _instance ??= new();

        public override string ToString() => $"Type Name: {GetType().Name.Split('+')[0]}";
    }
}


