using LightNovelLibrary.BuildingBlocks.Domain;
using LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess;
using LightNovelLibrary.Modules.LightNovel.Domain;

namespace LightNovelLibrary.Modules.LightNovel.Infrastructure.Repositories;

public class LightNovelRepository : ILightNovelRepository
{
    private readonly AppDbContext _context;
    private readonly IUnitOfWork _unitOfWork;

    public LightNovelRepository(AppDbContext context, IUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public IUnitOfWork UnitOfWork => _unitOfWork;

    public Domain.LightNovel? GetById(int id)
    {
        return _context.LightNovels.Where(n => n.LightNovelId == id).FirstOrDefault();
    }

    public void Add(Domain.LightNovel lightNovel)
    {
        _context.LightNovels.Add(lightNovel);
    }

    public Author? GetAuthorById(int id)
    {
        return _context.Authors.Where(a => a.AuthorId == id).FirstOrDefault();
    }

    public bool IsAuthorExists(int authorId)
    {
        return _context.Authors.Where(a => a.AuthorId == authorId).Any();
    }

    public bool IsTagsExist(IEnumerable<int> tagIds)
    {
        return _context.Tags.Where(t => tagIds.Contains(t.TagId)).Count() == tagIds.Count();
    }

}