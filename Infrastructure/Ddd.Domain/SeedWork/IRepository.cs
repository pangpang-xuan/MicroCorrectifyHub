namespace RecALLDemo.Infrastructure.Ddd.Domain.SeedWork;


public interface IRepository<TAggregateRoot>
    where TAggregateRoot : IAggregateRoot {
    //进行数据库操作，调用IUnitOfWork进行数据库的相关操作
    
    
    IUnitOfWork UnitOfWork { get; }
}

