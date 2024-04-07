using MediatR;
using Microsoft.AspNetCore.Mvc;
using RecALLDemo.Core.List.Api.Application.Commands;
using RecALLDemo.Core.List.Api.Infrastructure.Services;
using TheSalLab.GeneralReturnValues;

namespace RecALLDemo.Core.List.Api.Controllers;



[ApiController]
[Route("[controller]")]
public class ListController {
    
    private readonly IIdentityService _identityService;
    private readonly ILogger<ListController> _logger;
    private readonly IMediator _mediator; //中介者模式
    
    public ListController(IIdentityService identityService,
        ILogger<ListController> logger, IMediator mediator) {
        _identityService = identityService;
        _logger = logger;
        _mediator = mediator;
    }

    [Route("create")]
    [HttpPost]
    public async Task<ActionResult<ServiceResultViewModel>> CreateAsync(
        [FromBody] CreateListCommand command) {
        //controller -> command -> mediator -> commandhandler -> func Handle -> Repo -> func add -> UnitOfWork -> SaveEntitiesAsync
        
        _logger.LogInformation(
            "----- Sending command: {CommandName} - UserIdentityGuid: {userIdentityGuid} ({@Command})",
            command.GetType().Name, _identityService.GetUserIdentityGuid(),
            command);
        return (await _mediator.Send(command)).ToServiceResultViewModel();
    }



    
    
    


    
}