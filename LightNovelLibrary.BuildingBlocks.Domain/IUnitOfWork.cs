namespace LightNovelLibrary.BuildingBlocks.Domain;

public interface IUnitOfWork
{

    Task Commit();

}

