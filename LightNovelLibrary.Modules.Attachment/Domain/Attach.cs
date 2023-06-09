﻿using LightNovelLibrary.BuildingBlocks.Domain;

namespace LightNovelLibrary.Modules.Attachment.Domain;

public class Attach : EntityBase
{
    public long Id { get; set; }

    public string Name { get; set; } = string.Empty;

    public string MimeType { get; set; } = string.Empty;

    public int Size { get; set; }

    /// <summary>
    /// 代表一个协议，通过此协议可以获取到具体的附件
    /// </summary>
    public string Url { get; set; } = string.Empty;

    /// <summary>
    /// 缩略图文件类型
    /// </summary>
    public string ThumbnailMimeType { get; set; } = string.Empty;

    /// <summary>
    /// 缩略图下载地址
    /// </summary>
    public string ThumbnailUrl { get; set; } = string.Empty;

    /// <summary>
    /// 缩略图大小
    /// </summary>
    public int ThumbnailSize { get; set; }

    public DateTime? CreateTime { get; set; }

    /// <summary>
    /// 所有者类型
    /// </summary>
    public string? OwnerType { get; set; }

    /// <summary>
    /// 所有者ID
    /// </summary>
    public string? OwnerId { get; set; }

    /// <summary>
    /// 逻辑删除标志
    /// </summary>
    public bool IsDeleted { get; set; } = false;

    
}

