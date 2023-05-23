using LightNovelLibrary.Modules.Attachment.Domain;
using Microsoft.AspNetCore.Http;

namespace LightNovelLibrary.Modules.Attachment;

public class InMemoryAttachRepo : IAttachRepo
{
    private readonly IAttachStorage _attachStorage;
    private readonly IDictionary<long, Attach> _dictionary = new Dictionary<long, Attach>();
    private long _maxId = 0;

    public InMemoryAttachRepo(IAttachStorage attachStorage)
    {
        _attachStorage = attachStorage;
    }

    public IAttachStorage AttachStorage => _attachStorage;

    public void DeleteAttach(long attachId)
    {
        var attach = GetAttachById(attachId);
        attach.IsDeleted = true;
    }

    public byte[] FetchAttachBinary(long attachId)
    {
        var attach = GetAttachById(attachId);
        return _attachStorage.FetchAttach(attach.Url);
    }

    public Attach GetAttachById(long attachId)
    {
        return _dictionary[attachId];
    }

    public IList<Attach> GetAttachList(string ownerType, string ownerId)
    {
        return _dictionary.Values.Where(v => v.OwnerType == ownerType && v.OwnerId == ownerId).ToList();
    }

    public Attach SaveAttach(string ownerType, string ownerId, IFormFile formFile)
    {
        Attach attach = new Attach();
        attach.Url = _attachStorage.SaveFile(formFile);
        attach.Size = (int)formFile.Length;
        attach.Name = formFile.FileName;
        attach.MimeType = formFile.ContentType;
        attach.CreateTime = DateTime.UtcNow;
        return new Attach()
        {
            Id = Interlocked.Increment(ref _maxId),
            Url = _attachStorage.SaveFile(formFile),
            Size = (int)formFile.Length,
            Name = formFile.FileName,
            MimeType = formFile.ContentType,
            CreateTime = DateTime.UtcNow,
            OwnerType = ownerType,
            OwnerId = ownerId
        };
    }
}

