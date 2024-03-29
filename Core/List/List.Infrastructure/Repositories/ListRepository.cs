using Microsoft.EntityFrameworkCore;
using RecALLDemo.Core.List.Domain.AggregateModels.ListAggregate;
using RecALLDemo.Infrastructure.Ddd.Domain.SeedWork;

namespace RecALLDemo.Core.List.Infrastructure.Repositories;



public class ListRepository : IListRepository {
    private readonly ListContext _context;

    public IUnitOfWork UnitOfWork => _context;

    public ListRepository(ListContext context) {
        _context = context ?? throw new ArgumentNullException(nameof(context));
    }

    public Domain.AggregateModels.ListAggregate.List Add(
        Domain.AggregateModels.ListAggregate.List list) =>
        _context.Lists.Add(list).Entity;

    public async Task<Domain.AggregateModels.ListAggregate.List> GetAsync(
        int listId, string userIdentityGuid) {
        var list =
            await _context.Lists.FirstOrDefaultAsync(p =>
                p.Id == listId && p.UserIdentityGuid == userIdentityGuid &&
                !p.IsDeleted) ?? _context.Lists.Local.FirstOrDefault(p =>
                p.Id == listId && p.UserIdentityGuid == userIdentityGuid &&
                !p.IsDeleted);

        if (list is null) {
            return null;
        }

        await _context.Entry(list).Reference(p => p.Type).LoadAsync(); //利用主外键进行读区type属性
        return list;
    }
}
