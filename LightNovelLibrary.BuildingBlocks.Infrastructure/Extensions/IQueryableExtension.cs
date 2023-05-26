using LightNovelLibrary.BuildingBlocks.Domain.Pagination;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Extensions;

public static class IQueryableExtension
{
    public static IQueryable<T> Page<T>(this IQueryable<T> queryable, PaginationQuery paginationQuery)
    {
        return queryable.Skip((paginationQuery.PageNumber - 1) * paginationQuery.PageSize)
            .Take(paginationQuery.PageSize);
    }

    public static PaginationResult<T> AsPageResult<T>(this IQueryable<T> queryable)
    {
        return new PaginationResult<T>
        {
            Items = queryable.ToList(),
            Total = queryable.Count(),
        };
    }

}

