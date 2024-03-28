using MediatR;


namespace RecALLDemo.Core.List.Domain.Events;

public class ListDeletedDomainEvent : INotification {
    public AggregateModels.ListAggregate.List List { get; }

    public ListDeletedDomainEvent(AggregateModels.ListAggregate.List list) {
        List = list;
    }
    
    
}
