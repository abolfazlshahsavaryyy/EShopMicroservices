using Discount.Grpc.Data;
using Discount.Grpc.Models;
using Grpc.Core;
using Microsoft.EntityFrameworkCore;
using Mapster;


namespace Discount.Grpc.Services
{
    public class DiscountService
        (DiscountContext dbContext,ILogger<DiscountService> logger)
        :DiscountProtoService.DiscountProtoServiceBase
    {
        public override async Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            //TODO:get discount from the database
            var coupon = await dbContext.coupons
                .FirstOrDefaultAsync(c => c.ProductName == request.ProductName);
            if(coupon is null)
            {
                coupon= new Coupon {ProductName="No coupon", Amount=0,Description=$"Can't find the coupon for product{request.ProductName}" };
            }
            else
            {
                logger.LogInformation($"coupon retrrived with product name : {request.ProductName} and amount: {coupon.Amount}");
            }
            var couponModel = coupon.Adapt<CouponModel>();
            return couponModel;
        }
        public override Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            //TODO Create the Discount to  Database
            return base.CreateDiscount(request, context);
        }
        public override Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            //TODO Update the given Discount
            return base.UpdateDiscount(request, context);
        }
        public override Task<DeleteCouponResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            //TODO:Delete the Discount form the db
            return base.DeleteDiscount(request, context);
        }
        
    }
}
