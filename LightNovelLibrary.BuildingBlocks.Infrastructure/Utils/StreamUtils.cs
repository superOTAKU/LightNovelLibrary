using System.Text;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Utils;

public class StreamUtils
{

    public static string ReadUtf8String(Stream stream)
    {
        return ReadString(stream, Encoding.UTF8);
    }

    public static string ReadString(Stream stream, Encoding encoding)
    {
        using var reader = new StreamReader(stream, encoding);
        return reader.ReadToEnd();
    }

    public static byte[] ReadAllBytes(Stream stream)
    {
        using var memoryStream = new MemoryStream();
        byte[] buffer = new byte[1024];
        int bytesRead = 0;
        while ((bytesRead = stream.Read(buffer, 0, buffer.Length)) > 0)
        {
            memoryStream.Write(buffer, 0, bytesRead);
        }
        return memoryStream.ToArray();
    }

}

