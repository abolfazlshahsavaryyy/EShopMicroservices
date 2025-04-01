using MediatR;

namespace BuildingBlocks.CQRS
{
    /// <summary>
    /// specify that the ICommandHandler has the TRequest and TResponse and the TRequest should be command with the return type TResponse
    /// </summary>
    /// <typeparam name="TCommand"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface ICommandHandler<in TCommand, TResponse> :
        IRequestHandler<TCommand,TResponse>
        where TCommand:ICommand<TResponse>
        where TResponse : notnull
    {
        
    }

    /// <summary>
    /// ICommandHandler for Command witch has no specific response type
    /// </summary>
    /// <typeparam name="ICommand"></typeparam>
    public interface ICommandHandler<in ICommand>:
        IRequestHandler<ICommand,Unit>
        where ICommand : ICommand<Unit>
    {

    }
}
