using System.Net;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;

/// <summary>
/// 用于标注在业务异常上，表明希望返回的http状态码
/// </summary>
[AttributeUsage(AttributeTargets.Class)]
public class HttpStatusAttribute : Attribute
{
    public HttpStatusAttribute(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
    }

    public HttpStatusCode StatusCode { get; set; }
}

