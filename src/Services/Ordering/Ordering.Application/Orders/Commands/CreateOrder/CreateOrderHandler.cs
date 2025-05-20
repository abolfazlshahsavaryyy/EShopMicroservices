using BuildingBlocks.CQRS;

namespace Ordering.Application.Orders.Commands.CreateOrder;

class CreateOrderHandler : ICommandHandler<CreateOrderCommand, CreateOrderResult>
{
    public Task<CreateOrderResult> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        //create order entity from the given command that has order dto
        //save to database
        //return the result

        throw new NotImplementedException();
    }
}
