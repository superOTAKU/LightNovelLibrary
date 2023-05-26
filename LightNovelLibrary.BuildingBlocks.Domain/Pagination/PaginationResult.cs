namespace LightNovelLibrary.BuildingBlocks.Domain.Pagination;

public class PaginationResult<TResult>
{
    public IList<TResult> Items { get; set; } = new List<TResult>();

    public int Total { get; set; }

    public PaginationResult<TOther> Convert<TOther>(Func<TResult, TOther> convertor)
    {
        return new PaginationResult<TOther>
        {
            Items = Items.Select(convertor).ToList(),
            Total = Total
        };
    }

}

