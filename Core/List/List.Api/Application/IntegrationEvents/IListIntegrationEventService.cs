using RecALLDemo.Infrasturcture.EventBus.Events;

namespace RecALLDemo.Core.List.Api.Application.IntegrationEvents;




public interface IListIntegrationEventService {
    
    Task AddAndSaveEventAsync(IntegrationEvent integrationEvent);  //add and save

    Task PublishEventsAsync(Guid transactionId);  //publish
    
}
