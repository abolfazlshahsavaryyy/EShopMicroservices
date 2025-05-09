using Ordering.Domain.Abstractions;

namespace Ordering.Domain.Models
{
    public class Customer:Entity<CustomerId>
    {
        public string Name { get; private set; } = default!;
        public string Email { get; private set; }=default!;
        public static Customer Create(CustomerId Id,string name,string email)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(name);
            ArgumentException.ThrowIfNullOrWhiteSpace(email);
            var customer = new Customer
            {
                Name = name,
                Id = Id,
                Email = email
            };
            return customer;
        }

    }
}
