using Discount.Grpc.Models;
using Microsoft.EntityFrameworkCore;

namespace Discount.Grpc.Data
{
    public class DiscountContext:DbContext
    {
        public DiscountContext(DbContextOptions<DiscountContext> option):base(option)
        {
            
        }
        public DbSet<Coupon> coupons { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Coupon>().HasData(
                new Coupon { Id = 1, ProductName = "IPhone X", Description = "its phone", Amount = 899},
                new Coupon { Id = 2, ProductName = "IPhone 10", Description = "its good phone", Amount = 999 }
                );
        }
    }
}
