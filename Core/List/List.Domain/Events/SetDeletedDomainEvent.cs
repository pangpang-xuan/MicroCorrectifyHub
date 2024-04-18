using MediatR;
using RecALLDemo.Core.List.Domain.AggregateModels.SetAggregate;

namespace RecALLDemo.Core.List.Domain.Events;



public class SetDeletedDomainEvent : INotification {
    public Set Set { get; set; }

    public SetDeletedDomainEvent(Set set) {
        Set = set;
    }
}
