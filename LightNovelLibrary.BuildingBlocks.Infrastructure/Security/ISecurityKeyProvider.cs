using Microsoft.IdentityModel.Tokens;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Security;

/// <summary>
/// 密钥提供者，由于配置存在于API Assembly，提供此接口简化资源文件访问操作!!!
/// </summary>
public interface ISecurityKeyProvider
{
    SecurityKey GetSecretKey();

    SecurityKey GetPublicKey();
}

