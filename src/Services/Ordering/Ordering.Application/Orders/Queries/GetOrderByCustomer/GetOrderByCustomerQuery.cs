namespace Ordering.Application.Orders.Queries.GetOrderByCustomer;

public record GetOrderByCustomerResult(IEnumerable<OrderDto> orders);
public record GetOrderByCustomerQuery(Guid CustomerId):IQuery<GetOrderByCustomerResult>;

public class GetOrderByCustomerValidator : AbstractValidator<GetOrderByCustomerQuery>
{
    public GetOrderByCustomerValidator()
    {
        RuleFor(getOrderByCustomerQuery => getOrderByCustomerQuery.CustomerId)
            .NotNull()
            .WithMessage("CustomerId is required");
    }
}

