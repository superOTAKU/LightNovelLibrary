namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Security;

public interface IPasswordManager
{

    /// <summary>
    /// 对用户输入的密码源进行hash
    /// </summary>
    /// <param name="delegate">获取密码源的委托</param>
    /// <returns>hash过后的密码</returns>
    string Hash(PasswordSourceDelegate @delegate);

    /// <summary>
    /// 判断密码是否匹配
    /// </summary>
    /// <param name="delegate">获取密码源的委托</param>
    /// <param name="passwordHashed">hash过后的密码，一般存储在数据库</param>
    /// <returns></returns>
    bool IsMatch(PasswordSourceDelegate @delegate, string passwordHashed);

}

/// <summary>
/// 获取密码源的委托
/// 目的：抽象密码源，例如除了用户输入的密码，还可以加入随机盐值
/// </summary>
/// <returns>密码源</returns>
public delegate string PasswordSourceDelegate();

