using Bluscream;
using MMMUI.wrappers;
using System;
using System.IO;
using System.Reflection;
using System.Windows.Forms;

namespace MMMUI {
    public partial class MainForm : Form {
        MinecraftModManager wrapper;
        DirectoryInfo modDir;
        string mcVersion;

        public MainForm() {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e) {
            wrapper = new MinecraftModManager();

            var assembly = new FileInfo(Assembly.GetExecutingAssembly().Location);
            Text = $"Minecraft Mod Manager v{wrapper.mmmFile.GetVersion()} by {wrapper.mmmFile.GetAuthor()} (GUI v{assembly.GetVersion()} by {assembly.GetAuthor()})";
        }

        private void reloadToolStripMenuItem_Click(object sender, EventArgs e) => loadMods();
        private void loadMods() {
            if (modDir is null || !modDir.Exists) {
                modDir = askForModDir();
            }
            var mods = wrapper.GetMods(modDir);
            foreach (var mod in mods) {
                mod_table.Items.Add(new ListViewItem(mod.name));
            }
        }

        private DirectoryInfo askForModDir() {
            using (var fbd = new FolderBrowserDialog()) {
                fbd.Description = "Select mods directory";
                fbd.RootFolder = Environment.SpecialFolder.MyComputer;
                DialogResult result = fbd.ShowDialog();
                if (result == DialogResult.OK && Directory.Exists(fbd.SelectedPath)) {
                    return new DirectoryInfo(fbd.SelectedPath);
                } else if (result.isFalse()) {
                    return Utils.Exit();
                }
            }
            askForModDir();
            return null;
        }
    }
}
