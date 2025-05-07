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
        public override async Task<CouponModel> CreateDiscount(CreateDiscountRequest request, ServerCallContext context)
        {
            //TODO Create the Discount to  Database
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "invalid request object"));
            var result=await dbContext.coupons.AddAsync(coupon);
            var rowAffect=await dbContext.SaveChangesAsync();
            if (rowAffect > 0)
            {
                logger.LogInformation($"the new coupon has been added to db for product name : {request.Coupon.ProductName}");
                return coupon.Adapt<CouponModel>();
            }
            else
            {
                throw new RpcException(new Status(StatusCode.Internal, "can't add new coupon because of internal problem"));
            }


        }
        public override async Task<CouponModel> UpdateDiscount(UpdateDiscountRequest request, ServerCallContext context)
        {
            //TODO Update the given Discount
            var coupon = request.Coupon.Adapt<Coupon>();
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.InvalidArgument, "invalid request object"));
            var excisingCoupon= await dbContext.coupons.FindAsync(coupon.Id);
            excisingCoupon.ProductName = coupon.ProductName;
            excisingCoupon.Description = coupon.Description;
            excisingCoupon.Amount = coupon.Amount;


            var rowAffect = await dbContext.SaveChangesAsync();
            if (rowAffect > 0)
            {
                logger.LogInformation($"the new coupon has been added to db for product name : {request.Coupon.ProductName}");
                return coupon.Adapt<CouponModel>();
            }
            else
            {
                throw new RpcException(new Status(StatusCode.Internal, "can't add new coupon because of internal problem"));
            }
        }
        public override async Task<DeleteCouponResponse> DeleteDiscount(DeleteDiscountRequest request, ServerCallContext context)
        {
            //TODO:Delete the Discount form the db
            var coupon = await dbContext.coupons
                .FirstOrDefaultAsync(c => c.ProductName == request.ProductName);
            if (coupon is null)
                throw new RpcException(new Status(StatusCode.NotFound, $"Copoun with name : {request.ProductName} can't be find"));

            dbContext.coupons.Remove(coupon);
            var result=await dbContext.SaveChangesAsync();
            if (result > 0)
            {
                logger.LogInformation($"coupon for product with name : {request.ProductName} has been deleted successfully");
                return new DeleteCouponResponse { IsSuccess = true };
            }
            else
            {
                throw new RpcException(new Status(StatusCode.Internal, "internal error happend while deleted the coupon"));
                
            }

        }
        
    }
}
