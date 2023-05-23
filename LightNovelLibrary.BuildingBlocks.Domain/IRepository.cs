namespace LightNovelLibrary.BuildingBlocks.Domain;

/// <summary>
/// Repository Pattern
/// </summary>
public interface IRepository
{
    
    /// <summary>
    /// 当前关联的工作单元
    /// </summary>
    IUnitOfWork UnitOfWork { get; }

}

