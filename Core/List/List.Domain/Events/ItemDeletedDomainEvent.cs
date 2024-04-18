using MediatR;
using RecALLDemo.Core.List.Domain.AggregateModels.ItemAggregate;

namespace RecALLDemo.Core.List.Domain.Events;


public class ItemDeletedDomainEvent : INotification {
    public Item Item { get; set; }

    public ItemDeletedDomainEvent(Item item) {
        Item = item;
    }
}
