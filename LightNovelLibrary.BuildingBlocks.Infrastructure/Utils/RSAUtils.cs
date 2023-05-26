using Microsoft.IdentityModel.Tokens;
using System.Security.Cryptography;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Utils;

public class RSAUtils
{

    public static RsaSecurityKey ReadPublicKeyFromPem(string pem)
    {
        pem = pem.Replace("-----BEGIN PUBLIC KEY-----", "")
            .Replace("-----END PUBLIC KEY-----", "").Trim();
        var bytes = Convert.FromBase64String(pem);
        var rsa = RSA.Create();
        rsa.ImportSubjectPublicKeyInfo(bytes, out _);
        return new RsaSecurityKey(rsa);
    }


    public static RsaSecurityKey ReadPrivateKeyFromPem(string pem)
    {
        pem = pem.Replace("-----BEGIN PRIVATE KEY-----", "")
            .Replace("-----END PRIVATE KEY-----", "").Trim();
        var bytes = Convert.FromBase64String(pem);
        var rsa = RSA.Create();
        rsa.ImportPkcs8PrivateKey(bytes, out _);
        return new RsaSecurityKey(rsa);
    }

}

