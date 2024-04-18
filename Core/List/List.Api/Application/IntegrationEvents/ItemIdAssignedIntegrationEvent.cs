using RecALLDemo.Infrasturcture.EventBus.Events;

namespace RecALLDemo.Core.List.Api.Application.IntegrationEvents;


// 发送端

public record ItemIdAssignedIntegrationEvent(
    int typeId, 
    string contribId,
    int itemId) : IntegrationEvent;
