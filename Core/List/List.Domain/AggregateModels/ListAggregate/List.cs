using RecALLDemo.Core.List.Domain.Events;
using RecALLDemo.Core.List.Domain.Exceptions;
using RecALLDemo.Infrastructure.Ddd.Domain.SeedWork;

namespace RecALLDemo.Core.List.Domain.AggregateModels.ListAggregate;

public class List : Entity, IAggregateRoot {
    //领域驱动设计是读写分离，领域驱动设计只负责写数据，而唯一标识符和是否删除涉及到安全问题所以进行了公开
    //在进行创建新错题本，编辑错题本，删除错题本进行写数据
    
    private string _name; //错题本名字
    
    private int _typeId;  //错题本类型
    
    public ListType Type { get; private set; }

    private string _userIdentityGuid; //错题本属于谁

    public string UserIdentityGuid => _userIdentityGuid;

    private bool _isDeleted; //错题本有没有被删除

    public bool IsDeleted => _isDeleted;
    
    private List() { }
    
    //增
    public List(string name, int typeId, string userIdentityGuid) : this() {
        _name = name;
        _typeId = typeId;
        _userIdentityGuid = userIdentityGuid;
        
        var listCreatedDomainEvent = new ListCreatedDomainEvent(this);
        AddDomainEvent(listCreatedDomainEvent);
    }
    
    //删
    public void SetDeleted() {
        if (_isDeleted) {
            ThrowDeletedException();
        }

        _isDeleted = true;
        
        
        var listDeletedDomainEvent = new ListDeletedDomainEvent(this);
        AddDomainEvent(listDeletedDomainEvent);
    }
    
    //改
    public void SetName(string name) {
        if (_isDeleted) {
            ThrowDeletedException();
        }

        _name = name;
    }

    
    private void ThrowDeletedException() =>
        throw new ListDomainException("列表已删除。");


}