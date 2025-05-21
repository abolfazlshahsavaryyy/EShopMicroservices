namespace Ordering.Application.Orders.Commands.UpdateOrder;
public record UpdateOrderResult(bool IsSeccuss);
public record UpdateOrderCommand(OrderDto OrderDto)
    :ICommand<UpdateOrderResult>;

public class UpdateOrderCommandValidator : AbstractValidator<UpdateOrderCommand>
{
    public UpdateOrderCommandValidator()
    {
        RuleFor(o => o.OrderDto.Id).NotEmpty().WithMessage("Id is required");
        RuleFor(o => o.OrderDto.OrderName).NotEmpty().WithMessage("Order name is required");
        RuleFor(o => o.OrderDto.CustomerId).NotEmpty().WithMessage("Customer id can't be empty");
    }
}

