
namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;

/// <summary>
/// 自定义业务异常
/// </summary>
public abstract class BusinessException : Exception
{
    public BusinessException(int errorCode)
    {
        ErrorCode = errorCode;
    }

    public BusinessException(int errorCode, string? message) : base(message)
    {
        ErrorCode = errorCode;
    }

    public BusinessException(int errorCode, string? message, Exception? innerException) : base(message, innerException)
    {
        ErrorCode = errorCode;
    }

    public int ErrorCode { get; set; }
    
}

