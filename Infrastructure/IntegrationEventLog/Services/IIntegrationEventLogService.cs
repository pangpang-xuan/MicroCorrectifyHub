using Microsoft.EntityFrameworkCore.Storage;
using RecALLDemo.Infrasturcture.EventBus.Events;
using RecALLDemo.Infrasturcture.IntegrationEventLog.Models;

namespace RecALLDemo.Infrasturcture.IntegrationEventLog.Services;




public interface IIntegrationEventLogService {
    Task<IEnumerable<IntegrationEventLogEntry>>
        RetrieveEventLogsPendingToPublishAsync(Guid transactionId);

    Task SaveEventAsync(IntegrationEvent integrationEvent,
        IDbContextTransaction transaction);

    Task MarkEventAsPublishedAsync(Guid eventId);

    Task MarkEventAsInProgressAsync(Guid eventId);

    Task MarkEventAsFailedAsync(Guid eventId);
}
