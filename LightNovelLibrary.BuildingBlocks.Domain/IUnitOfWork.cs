namespace LightNovelLibrary.BuildingBlocks.Domain;

public interface IUnitOfWork
{

    Task CommitAsync(CancellationToken cancellationToken);

}

