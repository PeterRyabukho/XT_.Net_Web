using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Threading;
using System.Diagnostics;

namespace _5._1.BACKUP_SYSTEM
{
    public partial class MonitoringForm : Form
    {
        Observer observer = new Observer();
        Common common = new Common();
        public MonitoringForm()
        {
            InitializeComponent();
            this.Show();
        }

        private void SaveMeAs_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(newText.Text))
            {
                MessageBox.Show("Plese type some text", "Unable to save this text", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            saveFileDialog1.InitialDirectory = common.newPathFilesFolder;
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FileName = "";
            DialogResult result = saveFileDialog1.ShowDialog();

            if (result == DialogResult.OK)
            {
                File.WriteAllText(saveFileDialog1.FileName, newText.Text);
                //observer.Save(saveFileDialog1.FileName);

                MessageBox.Show("New .txt file created!", "Saving complite", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            SaveBackupChanges.Enabled = true;
        }

        private void FileSystemWatcher1_Changed(object sender, System.IO.FileSystemEventArgs eventFile)
        {
            observer.CreateBackup(sender, eventFile);
            Thread.Sleep(100);

            observer.CreateBackupDirectorys(sender, eventFile);
        }

        private void FileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs eventFile)
        {
            observer.CreateBackup(sender, eventFile);
            Thread.Sleep(100);

            observer.CreateBackupDirectorys(sender, eventFile);
        }

        public void CreateFolder_Click(object sender, EventArgs e)
        {
            //GetPathToFiles();
            common.CheckFolders();
            fileSystemWatcher1.Path = common.newPathFilesFolder;

            newText.Enabled = true;
            SaveMeAs.Enabled = true;
            openFolder.Enabled = true;
        }

        private void SaveBackupChanges_Click(object sender, EventArgs e)
        {
            File.WriteAllText(saveFileDialog1.FileName, newText.Text);
            saveBackupLabel.BackColor = Color.Red;
            saveBackupLabel.Enabled = true;
            Thread.Sleep(1000);
            saveBackupLabel.BackColor = Color.Empty;
            saveBackupLabel.Enabled = false;
        }

        private void GoToMenuButton_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
            this.Close();
        }

        private void FileSystemWatcher1_Deleted(object sender, FileSystemEventArgs eventFile)
        {
            observer.DeleteEventFileBackupsInFolder(sender, eventFile);

            bool eventFileEx = File.Exists(eventFile.FullPath);
            if (!eventFileEx)
            {
                observer.RemoveAndRenameFilesInDataDir(sender, eventFile);
            }
        }

        private void OpenFolder_Click(object sender, EventArgs e)
        {
            Process.Start(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-05\");
        }

        /// <summary>
        /// Dont work, Exeption: "This path is not supported!" ..... Dont know why(
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="eventFile"></param>
        //private void FileSystemWatcher1_Renamed(object sender, RenamedEventArgs eventFile)
        //{
        //    string fileName = Path.GetFileNameWithoutExtension(eventFile.OldName);
        //    string newFileName = Path.GetFileNameWithoutExtension(eventFile.Name);
        //    string[] directorys = Directory.GetDirectories(common.newPathBackupFolder);
        //    foreach (var dir in directorys)
        //    {
        //        DirectoryInfo dirInfo = new DirectoryInfo(dir);
        //        string dirname = dirInfo.Name;
        //        if (dirname == fileName)
        //        {
        //            string newDirName = Path.GetFileNameWithoutExtension(eventFile.Name);
        //            Directory.Move(dir, $@"{common.newPathBackupFolder}{newDirName}");

        //        }
        //    }

        //    string[] files = Directory.GetFiles($@"{common.newPathBackupFolder}{newFileName}");
        //    for (int i = 0; i < files.Length; i++)
        //    {
        //        DateTime dateTime = DateTime.Now;
        //        string serchFile = Path.GetFileNameWithoutExtension(files[i]);
        //        serchFile = serchFile.Substring(20);
        //        MessageBox.Show($"dir name - {files[i]}");
        //        string newDirCreate = $@"{common.newPathBackupFolder}{newFileName}";
        //        string dest = $@"{newDirCreate}\{dateTime}-{eventFile.Name}";
        //        MessageBox.Show($"file name - {dest}");
        //        File.Copy(files[i], dest,true);
        //    }
        //}
    }
}
