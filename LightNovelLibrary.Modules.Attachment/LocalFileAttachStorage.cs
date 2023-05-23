using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace LightNovelLibrary.Modules.Attachment;

/// <summary>
/// 存储附件到本地文件系统
/// </summary>
public class LocalFileAttachStorage : IAttachStorage
{
    private readonly LocalFileAttachStorageConfig _config;
    private readonly DirectoryInfo _directoryInfo;

    public LocalFileAttachStorage(IConfiguration configuration)
    {
        _config = configuration.GetSection("LocalFileAttachStorage").Get<LocalFileAttachStorageConfig>() 
            ?? throw new ArgumentNullException($"{nameof(LocalFileAttachStorage)} config not found");
        _directoryInfo = new DirectoryInfo(_config.BaseDir);
        if (!_directoryInfo.Exists)
        {
            throw new ArgumentException($"dir {_config.BaseDir} not exists");
        }
    }

    public void DeleteAttach(string url)
    {
        File.Delete(url);
    }

    public byte[] FetchAttach(string url)
    {
        return File.ReadAllBytes(url);
    }

    public string SaveFile(IFormFile formFile)
    {
        var guid = Guid.NewGuid().ToString();
        var path = Path.Combine(_directoryInfo.FullName, guid);
        using var file = File.Create(path);
        formFile.CopyTo(file);
        return path;
    }
}

/// <summary>
/// 配置参数
/// </summary>
public class LocalFileAttachStorageConfig
{
    /// <summary>
    /// 根目录
    /// </summary>
    public string BaseDir { get; set; } = string.Empty;
}

