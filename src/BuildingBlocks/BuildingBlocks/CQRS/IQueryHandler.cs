using MediatR;

namespace BuildingBlocks.CQRS
{
    /// <summary>
    /// IQuesryHandler for handler read operation 
    /// </summary>
    /// <typeparam name="TQuesry"></typeparam>
    /// <typeparam name="TResponse"></typeparam>
    public interface IQueryHandler<in TQuesry,TResponse>:
        IRequestHandler<TQuesry,TResponse>
        where TQuesry : IQuery<TResponse>
        where TResponse : notnull
    {
    }
    
}
