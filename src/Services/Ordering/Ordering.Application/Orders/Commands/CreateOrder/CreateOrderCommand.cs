using BuildingBlocks.CQRS;
using FluentValidation;
using FluentValidation.Validators;
using Ordering.Application.Dtos;

namespace Ordering.Application.Orders.Commands.CreateOrder;

public record CreateOrderResult(Guid Id); 
public record CreateOrderCommand(OrderDto order)
    :ICommand<CreateOrderResult>;

public class CreateOrderCommandValidation : AbstractValidator<CreateOrderCommand>
{
    public CreateOrderCommandValidation()
    {
        RuleFor(x => x.order.OrderName).NotEmpty().WithMessage("order name is required");
        RuleFor(x => x.order.CustomerId).NotNull().WithMessage("CustomerId is required");
        RuleFor(x => x.order.OrderItems).NotEmpty().WithMessage("Order item can't be empty");
    }
}

