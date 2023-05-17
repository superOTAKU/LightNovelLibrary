using Microsoft.AspNetCore.Http;

namespace LightNovelLibrary.Modules.Attachment;

/// <summary>
/// 附件存储引擎
/// </summary>
public interface IAttachStorage
{
    /// <summary>
    /// 存储formFile
    /// </summary>
    /// <param name="formFile"></param>
    /// <returns>附件url</returns>
    string SaveFile(IFormFile formFile);

    /// <summary>
    /// 删除附件
    /// </summary>
    /// <param name="url"></param>
    /// <returns>删除是否成功</returns>
    bool DeleteAttach(string url);

    /// <summary>
    /// 根据url获取二进制附件流
    /// </summary>
    /// <param name="url"></param>
    /// <returns></returns>
    byte[] FetchAttach(string url);

}

