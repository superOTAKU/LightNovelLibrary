using System.Net;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Rest;

[AttributeUsage(AttributeTargets.Class)]
public class HttpStatusAttribute : Attribute
{
    public HttpStatusAttribute(HttpStatusCode statusCode)
    {
        StatusCode = statusCode;
    }

    public HttpStatusCode StatusCode { get; set; }
}

