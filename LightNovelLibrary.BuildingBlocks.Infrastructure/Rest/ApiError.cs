namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;

public class ApiError
{
    public int ErrorCode { get; set; }

    public string? Message { get; set; }

    public object? Details { get; set; }

}

