namespace RecALLDemo.Infrastructure.Ddd.Domain.SeedWork;

public interface IUnitOfWork : IDisposable {
    Task<bool> SaveEntitiesAsync(CancellationToken cancellationToken = default); 
    
    //真正进行数据库操作的
}
