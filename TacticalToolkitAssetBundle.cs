using System;
using System.IO;
using System.Linq;
using System.Reflection;
using UnityEngine;

namespace TacticalToolkit
{
    public static class TacticalToolkitAssetBundle
    {
        public static AssetBundle LoadFromAssembly(Assembly assembly, string directory)
        {
            string resourceName = assembly.GetManifestResourceNames().FirstOrDefault(name => name.Equals(directory));

            if (resourceName != null)
            {
                using (Stream manifestResourceStream = assembly.GetManifestResourceStream(resourceName))
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    manifestResourceStream.CopyTo(memoryStream);
                    return AssetBundle.LoadFromMemory(memoryStream.ToArray());
                }
            }
            return null;
        }
    }
}
