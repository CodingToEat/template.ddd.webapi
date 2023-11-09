using MicroServiceName.Infra;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace MicroServiceName.App.Behav;

public class TransactionBehav<TRequest, TResponse>(MicroServiceNameCtx contextCtx) : IPipelineBehavior<TRequest, TResponse>
             where TRequest : notnull
             where TResponse : notnull
{
    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var response = default(TResponse);

        if (contextCtx.HasActiveTransaction)
        {
            return await next();
        }

        var strategy = contextCtx.Database.CreateExecutionStrategy();

        await strategy.ExecuteAsync(async () =>
        {
            Guid transactionId;

            using (var transaction = await contextCtx.BeginTransactionAsync())
            {
                response = await next();

                await contextCtx.CommitTransactionAsync(transaction);

                transactionId = transaction.TransactionId;
            }
        });

        return response;
    }
}