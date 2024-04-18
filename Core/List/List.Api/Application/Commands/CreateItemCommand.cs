using System.Text.Json.Nodes;
using MediatR;
using TheSalLab.GeneralReturnValues;

namespace RecALLDemo.Core.List.Api.Application.Commands;


public class CreateItemCommand : IRequest<ServiceResult> {
    public int SetId { get; set; }

    public JsonObject CreateContribJson { get; set; }
    
    //{ "setid":xxx,"CreateContribJson":{"content":xxx}}
    // 把图片存放在一个微服务中,将图片存放微服务中的id给json

    public CreateItemCommand(int setId, JsonObject createContribJson) {
        SetId = setId;
        CreateContribJson = createContribJson;
    }
}
