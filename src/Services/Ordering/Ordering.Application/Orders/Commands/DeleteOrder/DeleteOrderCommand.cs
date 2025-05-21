namespace Ordering.Application.Orders.Commands.DeleteOrder;

public record DeleteOrderResult(bool IsSuccess);
public record DeleteOrderCommand
    (Guid OrderId)
    :ICommand<DeleteOrderResult>;

public class DeleteOrderCommandValidation : AbstractValidator<DeleteOrderCommand>
{
    public DeleteOrderCommandValidation()
    {
        RuleFor(o => o.OrderId).NotEmpty().WithMessage("the order Id is required");
    }
}

