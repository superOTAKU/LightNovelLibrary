using LightNovelLibrary.BuildingBlocks.Domain;
using LightNovelLibrary.BuildingBlocks.Domain.Pagination;
using LightNovelLibrary.BuildingBlocks.Infrastructure.DataAccess;
using LightNovelLibrary.BuildingBlocks.Infrastructure.Extensions;
using LightNovelLibrary.Modules.LightNovel.Domain;
using Microsoft.EntityFrameworkCore;

namespace LightNovelLibrary.Modules.LightNovel.Infrastructure.Repositories;

public class LightNovelRepository : ILightNovelRepository
{
    private readonly LightNovelDbContext _context;
    private readonly LightNovelUnitOfWork _unitOfWork;

    public LightNovelRepository(LightNovelDbContext context, LightNovelUnitOfWork unitOfWork)
    {
        _context = context;
        _unitOfWork = unitOfWork;
    }

    public IUnitOfWork UnitOfWork => _unitOfWork;

    public Domain.LightNovel? GetById(int lightNovelId)
    {
        return GetById(lightNovelId, new GetLightNovelOptions());
    }

    public Domain.LightNovel? GetById(int id, GetLightNovelOptions? options)
    {
        options = options ?? new GetLightNovelOptions();
        var query = _context.LightNovels
            .Where(n => n.LightNovelId == id);
        if (options.IncludeTags)
        {
            query = query.Include(e => e.Tags);
        }
        if (options.IncludeAuthor)
        {
            query = query.Include(e => e.Author);
        }
        return query.FirstOrDefault();
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

    public IEnumerable<Tag> GetTags(IEnumerable<int> tagIds)
    {
        return _context.Tags.Where(t => tagIds.Contains(t.TagId));
    }

    public PaginationResult<Domain.LightNovel> GetLightNovelPage(LightNovelPaginationQuery query)
    {
        var q = _context.LightNovels.AsQueryable();
        if (query.AuthorId != null)
        {
            q = q.Where(e => e.AuthorId == query.AuthorId);
        }
        return q.Page(query).AsPageResult();
    }
}