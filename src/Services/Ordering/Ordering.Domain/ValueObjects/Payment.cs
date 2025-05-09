namespace Ordering.Domain.ValueObjects
{
    public record Payment
    {
        public string CartName { get; } = default!;
        public string CartNumber { get; } = default!;
        public string Expiraation { get; } = default!;
        public string CVV { get; } = default!;
        public int PaymentMethid { get; } = default!;
    }
}
