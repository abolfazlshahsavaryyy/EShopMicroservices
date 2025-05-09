using Ordering.Domain.Abstractions;

namespace Ordering.Domain.Models
{
    public class Cutomer:Entity<Guid>
    {
        public string Name { get; private set; } = default!;
        public string Email { get; private set; }=default!;

    }
}
