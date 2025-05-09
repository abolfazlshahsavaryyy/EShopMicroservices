namespace Ordering.Domain.ValueObjects
{
    public class OrderName
    {
        private const int DefaultLenght = 5;
        public string Value { get; }
        private  OrderName(string value)
        {
            this.Value = value;
        }
        public static OrderName Of(string value)
        {
            ArgumentException.ThrowIfNullOrEmpty(value);
            ArgumentOutOfRangeException.ThrowIfNotEqual(value.Length, DefaultLenght);
        }
    }
}
