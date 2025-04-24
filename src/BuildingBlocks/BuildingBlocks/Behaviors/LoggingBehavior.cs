using MediatR;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.Extensions.Logging;
using System.Diagnostics;

namespace BuildingBlocks.Behaviors
{
    public class LoggingBehavior<TRequest, TResponse>
        (ILogger<LoggingBehavior<TRequest, TResponse>> logger)
        : IPipelineBehavior<TRequest, TResponse>
        where TRequest :notnull,IRequest<TResponse>
        where TResponse:notnull
    {
        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            logger.LogInformation($"[START] Handle request={typeof(TRequest).Name} " +
                $"Response={typeof(TResponse).Name}" +
                $"Request Data={request.ToString()}");
            var timer = new Stopwatch();
            timer.Start();
            var respones =await  next();
            timer.Stop();
            var timerTaken = timer.Elapsed;
            if (timer.ElapsedMilliseconds > 3000)
            {
                logger.LogInformation($"[PERFORMANCE] the reques {typeof(TRequest).Name}" +
                    $" took {timerTaken.Seconds}");

            }
            logger.LogInformation($"[END] Handle {typeof(TRequest).Name} with {typeof(TResponse).Name}");
            return respones;
        }
    }
}
