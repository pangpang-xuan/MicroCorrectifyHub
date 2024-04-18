namespace RecALLDemo.Core.List.Api.Application.Queries;

public interface IListQueryService {
    
    //专门做数据库查询的
    Task<(IEnumerable<ListViewModel>, int)> ListAsync(int skip, int take,
        string userIdentityGuid);

    Task<(IEnumerable<ListViewModel>, int)> ListAsync(int typeId, int skip,
        int take, string userIdentityGuid);


    Task<ListViewModel> GetAsync(int id, string userIdentityGuid);
}
