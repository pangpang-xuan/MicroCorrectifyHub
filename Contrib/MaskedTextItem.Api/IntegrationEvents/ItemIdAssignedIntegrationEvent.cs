using RecALLDemo.Infrasturcture.EventBus.Events;

namespace RecALLDemo.Contrib.MaskedTextItem.Api.IntegrationEvents;

//接收端

public record ItemIdAssignedIntegrationEvent(
    int ItemId, 
    int TypeId,
    string ContribId) : IntegrationEvent;