namespace FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module3_FunctionalThinking
{
    public static class Calculator
    {
        private static Func<decimal, decimal, decimal> GetOperation(char operand)
        {
            switch (operand)
            {
                case '+': return (l, r) => l + r;
                case '-': return (l, r) => l - r;
                case '*': return (l, r) => l * r;
                case '/': return (l, r) => l / r;
            }

            throw new NotSupportedException("The supplied operator is not supported");
        }

        public static decimal Eval(string expressions)
        {
            var elements = expressions.Split([' '], 3);
            var l = decimal.Parse(elements[0]);
            var r = decimal.Parse(elements[1]);
            var operand = elements[2][0];
            return GetOperation(operand)(l, r);
        }
    }
}