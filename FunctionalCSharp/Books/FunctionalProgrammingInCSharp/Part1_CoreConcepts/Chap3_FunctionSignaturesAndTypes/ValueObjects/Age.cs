using FunctionalCSharp.Functional.ValueObjectClass;

namespace FunctionalCSharp.Books.FunctionalProgrammingInCSharp.Part1_CoreConcepts.Chap3_FunctionSignaturesAndTypes.ValueObjects
{
    public class Age : ValueObject<Age>
    {
        private Age(int age) => Value = age;

        public int Value { get; }

        public static Age CreateAge(int age){
            if (age is > 120 or < 0) throw new ArgumentOutOfRangeException(nameof(age));
            return new Age(age);
        }
        protected override bool EqualsCore(Age other) => Value == other.Value;
        protected override int GetHashCodeCore() => Value.GetHashCode();
    }
}