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
    }
}
