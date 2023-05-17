using LightNovelLibrary.Modules.Attachment.Domain;
using Microsoft.AspNetCore.Http;

namespace LightNovelLibrary.Modules.Attachment;

/// <summary>
/// 提供对附件的CURD，外围需要什么DTO，自己使用mapper来做映射
/// </summary>
public interface IAttachRepo
{
    /// <summary>
    /// 存储引擎
    /// </summary>
    IAttachStorage AttachStorage { get; }

    /// <summary>
    /// 保存附件
    /// </summary>
    /// <param name="ownerType"></param>
    /// <param name="ownerId"></param>
    /// <param name="formFile"></param>
    /// <returns></returns>
    Attach SaveAttach(string ownerType, string ownerId, IFormFile formFile);

    /// <summary>
    /// 查询附件列表
    /// </summary>
    /// <param name="ownerType"></param>
    /// <param name="ownerId"></param>
    /// <returns></returns>
    IList<Attach> GetAttachList(string ownerType, string ownerId);

    /// <summary>
    /// 根据id查询附件
    /// </summary>
    /// <param name="attachId"></param>
    /// <returns></returns>
    Attach GetAttachById(long attachId);

    /// <summary>
    /// 根据附件id，下载二进制流
    /// </summary>
    /// <param name="attachId"></param>
    /// <returns></returns>
    byte[] FetchAttachBinary(long attachId);

    /// <summary>
    /// 根据id删除附件
    /// </summary>
    /// <param name="attachId"></param>
    void DeleteAttach(long attachId);

}

