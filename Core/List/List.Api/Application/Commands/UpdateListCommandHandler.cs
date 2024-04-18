using MediatR;
using RecALLDemo.Core.List.Api.Infrastructure.Services;
using RecALLDemo.Core.List.Domain.AggregateModels.ListAggregate;
using TheSalLab.GeneralReturnValues;

namespace RecALLDemo.Core.List.Api.Application.Commands;


public class UpdateListCommandHandler : IRequestHandler<UpdateListCommand,
    ServiceResult> {
    private readonly IIdentityService _identityService;
    private readonly IListRepository _listRepository;
    private readonly ILogger<UpdateListCommandHandler> _logger;

    public UpdateListCommandHandler(IIdentityService identityService,
        IListRepository listRepository,
        ILogger<UpdateListCommandHandler> logger) {
        _identityService = identityService ??
                           throw new ArgumentNullException(nameof(identityService));
        _listRepository = listRepository ??
                          throw new ArgumentNullException(nameof(listRepository));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    public async Task<ServiceResult> Handle(UpdateListCommand command,
        CancellationToken cancellationToken) {
        (await _listRepository.GetAsync(command.Id,
            _identityService.GetUserIdentityGuid())).SetName(command.Name);
        return await _listRepository.UnitOfWork.SaveEntitiesAsync(
            cancellationToken)
            ? ServiceResult.CreateSucceededResult()
            : ServiceResult.CreateFailedResult();
    }
}
