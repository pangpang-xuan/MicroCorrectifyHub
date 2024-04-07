using MediatR;
using TheSalLab.GeneralReturnValues;

namespace RecALLDemo.Core.List.Api.Application.Commands;

public class CreateListCommand : IRequest<ServiceResult> {
    //继承规定返回值的类型是什么
    public string Name { get; set; }

    public int TypeId { get; set; }

    public CreateListCommand(string name, int typeId) {
        Name = name;
        TypeId = typeId;
    }
}