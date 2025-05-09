namespace Ordering.Domain.ValueObjects
{
    public record Payment
    {
        public string CartName { get; } = default!;
        public string CartNumber { get; } = default!;
        public string Expiration { get; } = default!;
        public string CVV { get; } = default!;
        public int PaymentMethid { get; } = default!;
        protected Payment()
        {

        }
        private Payment(string cartName,string cartNumber,string expiration,string cvv,int paymentMethod)
        {
            this.CartName = cartName;this.CartNumber = cartNumber;
            this.Expiration = expiration;this.CVV = cvv;
            this.PaymentMethid = paymentMethod;
        }
        public static Payment Of(string cartName, string cartNumber, string expiration, string cvv, int paymentMethod)
        {
            ArgumentException.ThrowIfNullOrEmpty(cartNumber);
            ArgumentException.ThrowIfNullOrEmpty(cartName);
            ArgumentException.ThrowIfNullOrEmpty(cvv);
            ArgumentOutOfRangeException.ThrowIfGreaterThanOrEqual(cvv.Length, 4);
            return new Payment(cartName, cartNumber, expiration, cvv, paymentMethod);

        }
    }
}
