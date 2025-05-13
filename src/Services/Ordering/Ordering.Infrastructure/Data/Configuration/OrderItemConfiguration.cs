using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configuration
{
    class OrderItemConfiguration : IEntityTypeConfiguration<OrderItem>
    {
        public void Configure(EntityTypeBuilder<OrderItem> builder)
        {
            builder.HasKey(oi => oi.Id);

            builder.Property(oi => oi.Id).HasConversion
                (
                orderItemId=>orderItemId.Value,
                dboi=>OrderItemId.Of(dboi)
                );
            //one to many relation for orderItem and Product
            builder.HasOne<Product>()
                .WithMany()
                .HasForeignKey(oi => oi.ProductId);

            builder.Property(oi => oi.Quantity).IsRequired();
            builder.Property(oi => oi.Price).IsRequired();

        }
    }
}
