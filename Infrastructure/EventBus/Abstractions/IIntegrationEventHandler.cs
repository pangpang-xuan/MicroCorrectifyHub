using RecALLDemo.Infrasturcture.EventBus.Events;

namespace RecALLDemo.Infrasturcture.EventBus.Abstractions;

//dapr负责收快递，这个负责处理快递

public interface
    IIntegrationEventHandler<TIntegrationEvent> : IIntegrationEventHandler
    where TIntegrationEvent : IntegrationEvent {
    Task Handle(TIntegrationEvent @event);
}

public interface IIntegrationEventHandler { }
