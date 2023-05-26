using System.Reflection;

namespace LightNovelLibrary.BuildingBlocks.Infrastructure.Utils;

public class AssemblyUtils
{

    public static Stream GetCallingAssmblyStream(string resourceName)
    {
        return Assembly.GetCallingAssembly().GetManifestResourceStream(resourceName) 
            ?? throw new ArgumentNullException($"resource {resourceName} is not exists");
    }

}

