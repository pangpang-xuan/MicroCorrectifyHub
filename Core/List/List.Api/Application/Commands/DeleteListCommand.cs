using MediatR;
using TheSalLab.GeneralReturnValues;

namespace RecALLDemo.Core.List.Api.Application.Commands;

public class DeleteListCommand : IRequest<ServiceResult> {
    public int Id { get; set; }

    public DeleteListCommand(int id) {
        Id = id;
    }
}
