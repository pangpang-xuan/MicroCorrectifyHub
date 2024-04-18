using MediatR;
using Microsoft.EntityFrameworkCore;
using RecALLDemo.Core.List.Api.Application.IntegrationEvents;
using RecALLDemo.Core.List.Infrastructure;
using Serilog.Context;

namespace RecALLDemo.Core.List.Api.Application.Behaviors;

// 事务拦截器


public class
    TransactionBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest,
        TResponse> where TRequest : IRequest<TResponse> {
    private readonly ILogger<TransactionBehaviour<TRequest, TResponse>> _logger;

    private readonly ListContext _listContext;

    private readonly IListIntegrationEventService _listIntegrationEventService; //集成事件

    public TransactionBehaviour(ListContext listContext,
        IListIntegrationEventService listIntegrationEventService,
        ILogger<TransactionBehaviour<TRequest, TResponse>> logger) {
        _listContext = listContext;
        _listIntegrationEventService = listIntegrationEventService;
        _logger = logger;
    }

    public async Task<TResponse> Handle(TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken) {
        var response = default(TResponse);
        var typeName = request.GetType().Name;

        try {
            if (_listContext.HasActiveTransaction) {
                return await next();
            }

            var strategy = _listContext.Database.CreateExecutionStrategy();

            await strategy.ExecuteAsync(async () => {
                Guid transactionId;
                await using var transaction =
                    await _listContext.BeginTransactionAsync();
                using (LogContext.PushProperty("TransactionContext",
                           transaction.TransactionId)) {
                    _logger.LogInformation(
                        "----- Begin transaction {TransactionId} for {CommandName} ({@Command})",
                        transaction.TransactionId, typeName, request);
                    response = await next();
                    _logger.LogInformation(
                        "----- Commit transaction {TransactionId} for {CommandName}",
                        transaction.TransactionId, typeName);

                    await _listContext.CommitTransactionAsync(transaction);
                    transactionId = transaction.TransactionId;
                }

                await _listIntegrationEventService.PublishEventsAsync(
                     transactionId);
                //   发布集成事务
            });

            return response;
        } catch (Exception e) {
            _logger.LogError(e,
                "ERROR Handling transaction for {CommandName} ({@Command})",
                typeName, request);
            throw;
        }
    }
}
