using Grpc.Core;

namespace Discount.Grpc.Services
{
    public class DiscountService:DiscountProtoService.DiscountProtoServiceBase
    {
        public override Task<CouponModel> GetDiscount(GetDiscountRequest request, ServerCallContext context)
        {
            //TODO:get discount from the database
            return base.GetDiscount(request, context);
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
