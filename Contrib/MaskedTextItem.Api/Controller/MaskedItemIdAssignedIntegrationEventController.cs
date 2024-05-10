using Dapr;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RecALLDemo.Contrib.MaskedTextItem.Api.IntegrationEvents;
using RecALLDemo.Contrib.MaskedTextItem.Api.Services;
using RecALLDemo.Core.List.Domain.AggregateModels;
using RecALLDemo.Infrasturcture.EventBus;

namespace RecALLDemo.Contrib.MaskedTextItem.Api.Controller;




[ApiController]
[Route("[controller]")]
public class ItemIdAssignedIntegrationEventController {
    private readonly MaskedTextItemContext _textItemContext;

    private readonly ILogger<ItemIdAssignedIntegrationEventController> _logger;

    public ItemIdAssignedIntegrationEventController(
        MaskedTextItemContext textItemContext,
        ILogger<ItemIdAssignedIntegrationEventController> logger) {
        _textItemContext = textItemContext;
        _logger = logger;
    }

    [Route("itemIdAssigned")]
    [HttpPost]
    [Topic(DaprEventBus.PubSubName, nameof(ItemIdAssignedIntegrationEvent))]
    public async Task HandleAsync(ItemIdAssignedIntegrationEvent @event) {
        if (@event.TypeId != 2)
        {
            _logger.LogInformation("----------------now type is {typenow}  so , it is not fit pass ----------------",@event.TypeId);
            return;
        }

        _logger.LogInformation(
            "----- Handling integration event: {IntegrationEventId} at {AppName} - ({@IntegrationEvent})",
            @event.Id, ProgramExtensions.AppName, @event);
        
        

        //var textItem = await _textItemContext.MaskedTextItems.FirstOrDefaultAsync(p =>
        //   p.Id == int.Parse(@event.ContribId));
        
        /*var textItem = await _textItemContext.MaskedTextItems.FirstOrDefaultAsync(p =>
        {
            bool isValidId = int.TryParse(@event.ContribId.Trim('\"'), out int parsedId);
            return isValidId && p.Id == parsedId;
        });*/
        
        var textItem = await _textItemContext.MaskedTextItems.FirstOrDefaultAsync(p =>
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