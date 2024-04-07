using MediatR;
using RecALLDemo.Core.List.Api.Infrastructure.Services;
using RecALLDemo.Core.List.Domain.AggregateModels.ListAggregate;
using TheSalLab.GeneralReturnValues;

namespace RecALLDemo.Core.List.Api.Application.Commands;


//一个command对应一个handler
//controller :转发命令
//command : 规定要求
//commandhandler: 负责命令的处理


public class CreateListCommandHandler : IRequestHandler
    <CreateListCommand, ServiceResult> {
    
    private readonly IIdentityService _identityService;
    private readonly IListRepository _listRepository;
    
    public CreateListCommandHandler(IIdentityService identityService,
        IListRepository listRepository) {
        _identityService = identityService;
        _listRepository = listRepository;
    }
    
    public async Task<ServiceResult> Handle(CreateListCommand command,
        CancellationToken cancellationToken) {
        _listRepository.Add(new Domain.AggregateModels.ListAggregate.List(
            command.Name, command.TypeId,
            _identityService.GetUserIdentityGuid())); //new对象并且add
        return await _listRepository.UnitOfWork.SaveEntitiesAsync(
            cancellationToken)
            ? ServiceResult.CreateSucceededResult()
            : ServiceResult.CreateFailedResult();
    }

}
