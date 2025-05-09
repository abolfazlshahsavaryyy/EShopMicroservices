namespace Ordering.Domain.ValueObjects
{
    public record Address
    {
        public string FirstName { get; } = default!;
        public string LastName { get; } = default!;
        public string? EmailAddress { get; } = default;
        public string AddressLine { get; } = default!;
        public string Country { get; } = default!;
        public string State { get; }= default!;
        public string ZipCode { get; } = default!;
        protected Address()
        {

        }
        private Address (string firstname,string lastname,string emailAddress,string addressLine,string country,string state,string zipCode)
        {
            this.FirstName = firstname;
            this.LastName = lastname;
            this.EmailAddress = emailAddress;
            this.AddressLine = addressLine;
            this.Country = country;
            this.State = state;
            this.ZipCode = zipCode;
        }
        public static Address Of(string firstname, string lastname, string emailAddress, string addressLine, string country, string state, string zipCode)
        {
            ArgumentException.ThrowIfNullOrEmpty(emailAddress);
            ArgumentException.ThrowIfNullOrEmpty(addressLine);
            return new Address(firstname, lastname, emailAddress, addressLine, country, state, zipCode);
        }

    }
    
}
