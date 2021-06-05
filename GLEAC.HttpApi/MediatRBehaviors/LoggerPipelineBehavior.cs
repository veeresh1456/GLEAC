using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.Extensions.Logging;

namespace GLEAC.HttpApi.MediatRBehaviors
{
    public class LoggerPipelineBehavior<TRequest, TResponse>
        : IPipelineBehavior<TRequest, TResponse>
    {
        private readonly ILogger<LoggerPipelineBehavior<TRequest, TResponse>> logger;

        public LoggerPipelineBehavior(ILogger<LoggerPipelineBehavior<TRequest, TResponse>> logger)
        {
            this.logger = logger;
        }
        public async Task<TResponse> Handle(TRequest request, CancellationToken cancellationToken, RequestHandlerDelegate<TResponse> next)
        {
            logger.LogInformation("ExecutingRequest {Request} with params : {@params}.", typeof(TRequest).Name, request);

            var response = await next();

            logger.LogInformation("ExecutedRequest {Request}.", typeof(TRequest).Name);

            return response;
        }
    }
}
