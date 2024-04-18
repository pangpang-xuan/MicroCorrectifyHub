using RecALLDemo.Core.List.Domain.Events;
using RecALLDemo.Core.List.Domain.Exceptions;
using RecALLDemo.Infrastructure.Ddd.Domain.SeedWork;

namespace RecALLDemo.Core.List.Domain.AggregateModels.ItemAggregate;

public class Item: Entity,IAggregateRoot {
    
    private int _typeId;  //题目的类型

    public ListType Type { get; private set; }

    private int _setId;  //题目所属的集合

    public int SetId => _setId;
    
    private string _contribId;  //下层微服务的主键

    public string ContribId => _contribId;
    
    private string _userIdentityGuid;  //用户唯一标识符

    public string UserIdentityGuid => _userIdentityGuid;

    private bool _isDeleted;   //软删除

    public bool IsDeleted => _isDeleted;
    private Item() { }

    public Item(int typeId, int setId, string contribId,
        string userIdentityGuid) : this() {
        _typeId = typeId;
        _setId = setId;
        _contribId = contribId;
        _userIdentityGuid = userIdentityGuid;

        var itemCreatedDomainEvent = new ItemCreatedDomainEvent(this);
        AddDomainEvent(itemCreatedDomainEvent);
    }

    public void SetSetId(int setId) {
        if (_isDeleted) {
            ThrowDeletedException();
        }

        _setId = setId;
    }

    public void SetDeleted() {
        if (_isDeleted) {
            ThrowDeletedException();
        }

        _isDeleted = true;

        var itemDeletedDomainEvent = new ItemDeletedDomainEvent(this);
        AddDomainEvent(itemDeletedDomainEvent);
    }

    private void ThrowDeletedException() =>
        throw new ListDomainException("项目已删除。");



    
}