using Bluscream;
using MMMUI.wrappers.mmm;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;

namespace MMMUI.wrappers {
    internal class MinecraftModManager {
        static DirectoryInfo searchDir = Environment.SpecialFolder.ApplicationData.Combine("Python", "Python311", "Scripts");
        static string[] searchPaths = { "mmm.exe", "mcman.exe", "minecraft-mod-manager.exe", "" };
        public FileInfo mmmFile;


        public MinecraftModManager() {
            Console.WriteLine("MinecraftModManager");
            mmmFile = Find();
            Console.WriteLine($"Using {mmmFile.FullName}");

        }

        public FileInfo Find() {
            foreach (var binFile in searchPaths) {
                var file = searchDir.CombineFile(binFile);
                // Console.WriteLine(file.FullName);
                if (file.Exists) return file;
            }
            return AskForMMM();
        }
        public FileInfo AskForMMM() {

            using (OpenFileDialog openFileDialog = new OpenFileDialog()) {
                openFileDialog.Title = "Select Minecraft Mod Manager Executable";
                openFileDialog.InitialDirectory = "c:\\";
                openFileDialog.Filter = "mmm.exe|mmm.exe|mcman.exe|mcman.exe|minecraft-mod-manager.exe|minecraft-mod-manager.exe|All files (*.*)|*.*";
                openFileDialog.FilterIndex = 2;
                openFileDialog.RestoreDirectory = true;
                var dialog = openFileDialog.ShowDialog();
                if (dialog == DialogResult.OK && File.Exists(openFileDialog.FileName)) {
                    return new FileInfo(openFileDialog.FileName);
                } else if (dialog == DialogResult.Cancel) {
                    return Utils.Exit();
                }
            }
            AskForMMM();
            throw new Exception("Unable to locate MMM, can't continue!");
        }

        public List<ModInfo> GetMods(DirectoryInfo dir) {
            var mods = new List<ModInfo>();
            foreach (var file in dir.GetFiles("*.jar")) {
                mods.Add(new ModInfo(file));
            }
            return mods;
        }

        public List<ModInfo> CheckMods(DirectoryInfo dir) {
            return null;
        }
    }
}