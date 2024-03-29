using RecALLDemo.Infrastructure.Ddd.Domain.SeedWork;

namespace RecALLDemo.Core.List.Domain.AggregateModels.ListAggregate;



public interface IListRepository : IRepository<List> {
    List Add(List list);

    Task<List> GetAsync(int listId, string userIdentityGuid);
}
