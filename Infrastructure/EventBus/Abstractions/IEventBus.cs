using RecALLDemo.Infrasturcture.EventBus.Events;

namespace RecALLDemo.Infrasturcture.EventBus.Abstractions;

//负责发快递

public interface IEventBus {
    Task PublishAsync(IntegrationEvent @event);
}

