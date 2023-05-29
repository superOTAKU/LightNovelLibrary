using System.Security.Cryptography;
using System.Text;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Security;

public class Md5PasswordManager : IPasswordManager
{
    public Md5PasswordManager()
    {
        
    }

    public string Hash(PasswordSourceDelegate @delegate)
    {
        return Encoding.UTF8.GetString(MD5.HashData(Encoding.UTF8.GetBytes(@delegate())));
    }

    public bool IsMatch(PasswordSourceDelegate @delegate, string passwordHashed)
    {
        return Hash(@delegate) == passwordHashed;
    }

}

