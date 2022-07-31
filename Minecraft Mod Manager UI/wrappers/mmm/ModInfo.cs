using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using Bluscream;

namespace MMMUI.wrappers.mmm {
    internal class ModInfo {
        public FileInfo file;
        public string name;
        public string id;
        public Version version;
        public ModInfo(FileInfo file) {
            this.file = file;
            this.name = file.FileNameWithoutExtension();
        }
        public ModInfo parse(List<string> lines) {
            foreach (string line in lines) {
                Console.WriteLine(line);
            }
            return this;
        }
    }
}
