namespace LightNovelLibrary.BuildingBlocks.Domain;

public interface IEntity
{
    public IList<IDomainEvent> DomainEvents { get; }

    /// <summary>
    /// 添加领域事件，应该只会在领域对象内部被调用
    /// </summary>
    /// <param name="domainEvent"></param>
    public void AddDomainEvent(IDomainEvent domainEvent);

    /// <summary>
    /// 获取领域事件，同时清空自己持有的事件
    /// </summary>
    /// <returns>已发生的领域事件</returns>
    public IList<IDomainEvent> PollDomainEvents();
}
