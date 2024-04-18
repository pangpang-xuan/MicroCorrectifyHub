using MediatR;
using RecALLDemo.Core.List.Domain.AggregateModels.SetAggregate;

namespace RecALLDemo.Core.List.Domain.Events;

public class SetCreatedDomainEvent : INotification {
    public Set Set { get; }

    public SetCreatedDomainEvent(Set set) {
        Set = set;
    }
}
