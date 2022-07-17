using System.Text;

namespace FunctionalCSharp.Functional.MethodChaining.With
{
    public static class StringBuilderExtensions
    {
        public static StringBuilder AppendFormattedLine(this StringBuilder @this, string format, params object[] args)
            => @this.AppendFormat(format, args).AppendLine();

        // public static StringBuilder AppendLineWhen(this StringBuilder @this, Func<bool> predicate, string value)
        //     => predicate() ? @this.AppendLine(value) : @this;

        public static StringBuilder AppendWhen(this StringBuilder @this,
            Func<bool> predicate,
            Func<StringBuilder, StringBuilder> func)
            => predicate() ? func(@this) : @this;

        public static StringBuilder AppendSequence<T>(this StringBuilder @this,
            IEnumerable<T> sequence,
            Func<StringBuilder, T, StringBuilder> func)
            => sequence.Aggregate(@this, func);
    }
}