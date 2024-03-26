using System.Text;

namespace FunctionalCSharp.Courses.FunctionalProgrammingWithCSharp.Module4GoingWithTheFlow.MethodChaining.With;

public static class StringBuilderExtensions
{
        public static StringBuilder AppendWhen(this StringBuilder sb, Func<bool> isTrueOrFalse, Func<StringBuilder,StringBuilder> func) 
            => isTrueOrFalse() ? func(sb) : sb;
        
        public static StringBuilder AppendSequence<T>(this StringBuilder sb, IEnumerable<T> sequence,
            Func<StringBuilder, T, StringBuilder> fn) => sequence.Aggregate(sb, fn);
        public static StringBuilder AppendFormattedLine(this StringBuilder sb, string format,  params object[] args) 
            => sb.AppendFormat(format, args).AppendLine();




    // public static StringBuilder AppendFormattedLine(this StringBuilder @this, string format, params object[] args)
    //     => @this.AppendFormat(format, args).AppendLine();
    //
    // // public static StringBuilder AppendLineWhen(this StringBuilder @this, Func<bool> predicate, string value)
    // //     => predicate() ? @this.AppendLine(value) : @this;
    //
    // public static StringBuilder AppendWhen(this StringBuilder @this,
    //     Func<bool> predicate,
    //     Func<StringBuilder, StringBuilder> func)
    //     => predicate() ? func(@this) : @this;
    //
    // public static StringBuilder AppendSequence<T>(this StringBuilder @this,
    //     IEnumerable<T> sequence,
    //     Func<StringBuilder, T, StringBuilder> func)
    //     => sequence.Aggregate(@this, func);
}