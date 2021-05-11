namespace Fou.Utils
{
    public class Option<T>
    {
        public Option(T value)
        {
            Value    = value;
            HasValue = true;
        }

        private Option()
        {
            Value    = default;
            HasValue = false;
        }

        public T    Value    { get; }
        public bool HasValue { get; }

        public static Option<T> Empty => new Option<T>();

        public static implicit operator T(Option<T> option)
        {
            return option.Value;
        }

        public static explicit operator Option<T>(T value)
        {
            return new Option<T>(value);
        }
    }
}