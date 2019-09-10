namespace Fou.Utils
{
    public class Option<T>
    {
        public T Value { get; }
        public bool HasValue { get; }

        public Option(T value)
        {
            Value = value;
            HasValue = true;
        }

        private Option()
        {
            Value = default;
            HasValue = false;
        }

        public static implicit operator T(Option<T> option) => option.Value;
        public static explicit operator Option<T>(T value) => new Option<T>(value);

        public static Option<T> Empty => new Option<T>();
    }
}
