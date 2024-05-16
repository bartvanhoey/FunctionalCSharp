using static FunctionalCSharp.MyYumba.Y;
using Unit = System.ValueTuple;

namespace FunctionalCSharp.MyYumba;

public static partial class Y
{
    public static YEither.YLeft<L> YLeft<L>(L l) => new(l);
    public static YEither.YRight<R> YRight<R>(R r) => new(r);
}

public struct YEither<L,R>
{
    private L? YLeft { get; }
    private R? YRight { get; }
    private bool IsRight { get; }
    private bool IsLeft => !IsRight;

    internal YEither(L left)
        => (IsRight, YLeft, YRight) = (false, left ?? throw new ArgumentNullException(nameof(left)), default);

    internal YEither(R right)
        => (IsRight, YLeft, YRight)
            = (true, default, right ?? throw new ArgumentNullException(nameof(right)));

    public static implicit operator YEither<L, R>(L left) => new(left);
    public static implicit operator YEither<L, R>(R right) => new(right);

    public static implicit operator YEither<L, R>(YEither.YLeft<L> left) => new(left.Value);
    public static implicit operator YEither<L, R>(YEither.YRight<R> right) => new(right.Value);

    public Tr YMatch<Tr>(Func<L, Tr> left, Func<R, Tr> right)
        => IsLeft ? left(this.YLeft!) : right(this.YRight!);

    public Unit YMatch(Action<L> left, Action<R> right)
        => YMatch(left.YToFunc(), right.YToFunc());

    public IEnumerator<R> AsEnumerable()
    {
        if (IsRight) yield return YRight!;
    }

    public override string ToString() => YMatch(l => $"Left({l})", r => $"Right({r})");
}

public static class YEither
{
    public struct YLeft<L>
    {
        internal L Value { get; }

        internal YLeft(L value) => Value = value;
        public override string ToString() => $"Left({Value})";
    }
    public struct YRight<R>
    {
        internal R Value { get; }

        internal YRight(R value) => Value = value;
        public override string ToString() => $"Right({Value})";

        public YRight<Rr> YMap<L, Rr>(Func<R, Rr> f) => YRight(f(Value));
        public YEither<L, Rr> YBind<L, Rr>(Func<R, YEither<L, Rr>> f) => f(Value);
    }
}