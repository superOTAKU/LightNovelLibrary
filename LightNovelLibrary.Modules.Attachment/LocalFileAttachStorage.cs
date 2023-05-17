using Microsoft.AspNetCore.Http;

namespace LightNovelLibrary.Modules.Attachment;

public class LocalFileAttachStorage : IAttachStorage
{
    public bool DeleteAttach(string url)
    {
        throw new NotImplementedException();
    }

    public byte[] FetchAttach(string url)
    {
        throw new NotImplementedException();
    }

    public string SaveFile(IFormFile formFile)
    {
        throw new NotImplementedException();
    }
}

