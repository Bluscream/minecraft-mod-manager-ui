using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Minecraft_Mod_Manager_UI.wrappers
{
    internal class MinecraftModManager
    {
        static DirectoryInfo searchDir = new DirectoryInfo(@"C:\Users\blusc\AppData\Roaming\Python\Python311\Scripts");
        static string[] searchPaths = {"mmm.exe", "mcman.exe", "minecraft-mod-manager.exe", ""};
        FileInfo mmmFile;

        public MinecraftModManager()
        {

        }

        public void Find()
        {
            foreach (var binFile in searchPaths)
            {
                var file = searchDir.com
            }
        }
    }
}