using RecALLDemo.Core.List.Domain.AggregateModels;
using RecALLDemo.Infrastructure.Ddd.Domain.SeedWork;

namespace RecALLDemo.Core.List.Api.Infrastructure.Services;



public class ContribUrlService : IContribUrlService {
    public string GetContribUrl(int listTypeId) {
        string route;

        if (listTypeId == ListType.Text.Id) {
            route = "text";  //根据不同的类型转发到不同的网关
        } else {
            throw new ArgumentOutOfRangeException(nameof(listTypeId),
                $"有效取值为{string.Join(",", Enumeration.GetAll<ListType>().Select(p => p.Id.ToString()))}");
        }

        return $"http://recall-envoygateway/{route}";
    }
}
