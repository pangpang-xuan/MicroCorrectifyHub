using MediatR;
using RecALLDemo.Core.List.Domain.AggregateModels.ItemAggregate;

namespace RecALLDemo.Core.List.Domain.Events;

public class ItemCreatedDomainEvent : INotification {
    public Item Item { get; }

    public ItemCreatedDomainEvent(Item item) {
        Item = item;
    }
}
