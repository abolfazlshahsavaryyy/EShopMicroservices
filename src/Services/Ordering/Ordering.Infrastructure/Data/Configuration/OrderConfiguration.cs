using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Ordering.Domain.Enums;
using Ordering.Domain.Models;
using Ordering.Domain.ValueObjects;

namespace Ordering.Infrastructure.Data.Configuration
{
    public class OrderConfiguration : IEntityTypeConfiguration<Order>
    {
        public void Configure(EntityTypeBuilder<Order> builder)
        {
            builder.HasKey(o => o.Id);
            builder.Property(o => o.Id).HasConversion(
                orderId=>orderId.Value,
                dbId=>OrderId.Of(dbId)
                );

            builder.HasOne<Customer>()
                .WithMany()
                .HasForeignKey(x => x.CustomerId)
                .IsRequired();

            builder.HasMany<OrderItem>()
                .WithOne()
                .HasForeignKey(x => x.OrderId);

            //first we defind the complex property in db
            builder.ComplexProperty
                (
                //set the property 
                o => o.OrderName, nameBuilder =>
                {
                    //set what value should be in db 
                    nameBuilder.Property(n => n.Value)
                    //witch with column name in db
                    .HasColumnName(nameof(Order.OrderName))
                    //validation on max lenght
                    .HasMaxLength(100)
                    //required
                    .IsRequired();
                }
                );

            builder.ComplexProperty
                (
                o => o.ShippingAddress, addressBuilder =>
                {
                    addressBuilder.Property(a => a.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                    addressBuilder.Property(a => a.LastName)
                    .HasMaxLength(50)
                    .IsRequired();
                    addressBuilder.Property(a => a.EmailAddress)
                    .HasMaxLength(50);

                    addressBuilder.Property(a => a.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                    addressBuilder.Property(a => a.Country)
                    .HasMaxLength(50);

                    addressBuilder.Property(a => a.State)
                    .HasMaxLength(50);

                    addressBuilder.Property(a => a.ZipCode)
                    .HasMaxLength(50).IsRequired();
                    


                    
                }


                );

            builder.ComplexProperty
                (
                o => o.BillingAddress, addressBuilder =>
                {
                    addressBuilder.Property(a => a.FirstName)
                    .HasMaxLength(50)
                    .IsRequired();

                    addressBuilder.Property(a => a.LastName)
                    .HasMaxLength(50)
                    .IsRequired();
                    addressBuilder.Property(a => a.EmailAddress)
                    .HasMaxLength(50);

                    addressBuilder.Property(a => a.AddressLine)
                    .HasMaxLength(180)
                    .IsRequired();

                    addressBuilder.Property(a => a.Country)
                    .HasMaxLength(50);

                    addressBuilder.Property(a => a.State)
                    .HasMaxLength(50);

                    addressBuilder.Property(a => a.ZipCode)
                    .HasMaxLength(50).IsRequired();




                }


                );

            builder.ComplexProperty(o => o.Payment, paymentBuilder =>
            {
                paymentBuilder.Property(p => p.CartName)
                .HasMaxLength(50);

                paymentBuilder.Property(p => p.CartNumber)
                .HasMaxLength(24).IsRequired();

                paymentBuilder.Property(p => p.Expiration)
                .HasMaxLength(10);
                paymentBuilder.Property(p => p.CVV)
                .HasMaxLength(3);
                paymentBuilder.Property(p => p.PaymentMethid);
            });


            builder.Property(o => o.Status)
                .HasDefaultValue(OrderStatus.Draft)
                .HasConversion
                (
                s => s.ToString(),
                dbStatus => (OrderStatus)Enum.Parse(typeof(OrderStatus),dbStatus) 
                );

            builder.Property(o => o.TotalPrice);




        }
    }
}
