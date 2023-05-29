namespace LightNovelLibrary.BuildingBlocks.Domain;

public interface IDomainEvent
{
    /// <summary>
    /// 发生事件
    /// </summary>
    public DateTime OccurredOn { get; }

    /// <summary>
    /// 事件唯一标识
    /// </summary>
    public Guid Guid { get; }
}