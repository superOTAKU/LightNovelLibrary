using LightNovelLibrary.BuildingBlocks.Infrastructure.Security;
using LightNovelLibrary.BuildingBlocks.Infrastructure.Utils;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Caching.Memory;
using Microsoft.IdentityModel.Tokens;

namespace LightNovelLibrary.API.Security;

public class SecurityKeyProvider : ISecurityKeyProvider
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// 密钥缓存
    /// </summary>
    private MemoryCache _securityKeyCache = new MemoryCache(new MemoryCacheOptions());

    public SecurityKeyProvider(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// 封装读取key的逻辑，Program初始化JWT Authentication时会用到
    /// </summary>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static SecurityKey ReadPrivateKey(String resourceName)
    {
        using Stream stream = AssemblyUtils.GetCallingAssmblyStream(resourceName);
        return RSAUtils.ReadPrivateKeyFromPem(StreamUtils.ReadUtf8String(stream));
    }


    /// <summary>
    /// 封装读取key的逻辑，Program初始化JWT Authentication时会用到
    /// </summary>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static SecurityKey ReadPublicKey(String resourceName)
    {
        using Stream stream = AssemblyUtils.GetCallingAssmblyStream(resourceName);
        return RSAUtils.ReadPublicKeyFromPem(StreamUtils.ReadUtf8String(stream));
    }

    public SecurityKey GetPublicKey()
    {
        return _securityKeyCache.GetOrCreate<SecurityKey>("publicKey", _ =>
        {
            return ReadPublicKey(_configuration["JwtSettings:PublicKey"]!);
        })!;
    }

    public SecurityKey GetSecretKey()
    {
        return _securityKeyCache.GetOrCreate<SecurityKey>("privateKey", _ =>
        {
            return ReadPrivateKey(_configuration["JwtSettings:PrivateKey"]!);
        })!;
    }
}
