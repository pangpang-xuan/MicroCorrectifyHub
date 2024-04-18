using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecALLDemo.Contrib.TextItem.Api.IntegrationEvents;
using RecALLDemo.Contrib.TextItem.Api.Services;
using RecALLDemo.Core.List.Domain.AggregateModels;
using RecALLDemo.Infrasturcture.EventBus;

namespace RecALLDemo.Contrib.TextItem.Api.Controller;




[ApiController]
[Route("[controller]")]
public class ItemIdAssignedIntegrationEventController {
    private readonly TextItemContext _textItemContext;

    private readonly ILogger<ItemIdAssignedIntegrationEventController> _logger;

    public ItemIdAssignedIntegrationEventController(
        TextItemContext textItemContext,
        ILogger<ItemIdAssignedIntegrationEventController> logger) {
        _textItemContext = textItemContext;
        _logger = logger;
    }

    [Route("itemIdAssigned")]
    [HttpPost]
    [Topic(DaprEventBus.PubSubName, nameof(ItemIdAssignedIntegrationEvent))]
    public async Task HandleAsync(ItemIdAssignedIntegrationEvent @event) {
        if (@event.TypeId != ListType.Text.Id) {
            return;
        }

        _logger.LogInformation(
            "----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})",
            @event.Id, ProgramExtensions.AppName, @event);

        var textItem = await _textItemContext.TextItems.FirstOrDefaultAsync(p =>
            p.Id == int.Parse(@event.ContribId));

        if (textItem is null) {
            _logger.LogWarning("Unknown TextItem id: {ItemId}", @event.ItemId);
            return;
        }

        textItem.ItemId = @event.ItemId;
        await _textItemContext.SaveChangesAsync();

        _logger.LogInformation(
            "----- Integration event handled: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})",
            @event.Id, ProgramExtensions.AppName, @event);
    }
}
