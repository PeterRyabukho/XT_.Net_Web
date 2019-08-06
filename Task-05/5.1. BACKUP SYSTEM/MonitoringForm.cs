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

namespace _5._1.BACKUP_SYSTEM
{
    public partial class MonitoringForm : Form
    {
        Observer observer = new Observer();
        public MonitoringForm()
        {
            InitializeComponent();
            this.Show();
        }
        private int count = 0;

        private void GetPathToFiles()
        {
            observer.newPathBackupFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-05\Backup folder\";
            observer.newPathFilesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-05\Files folder";
            observer.PathBackupFoldersWithDate = $@"{observer.newPathBackupFolder}Date Backup Folders\";
        }
        private void CheckFolders()
        {
            bool directoryExists1 = Directory.Exists(observer.newPathBackupFolder);
            bool directoryExists2 = Directory.Exists(observer.newPathFilesFolder);
            if (directoryExists1 && directoryExists2)
            {
                MessageBox.Show("Directorys already exists!", "Directorys OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Directory.CreateDirectory(observer.newPathBackupFolder);
                Directory.CreateDirectory(observer.newPathFilesFolder);
                MessageBox.Show($"Folders creating complite:{Environment.NewLine}{ observer.newPathBackupFolder}{Environment.NewLine}{observer.newPathFilesFolder}", 
                                "Folders created!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            fileSystemWatcher1.Path = observer.newPathFilesFolder;
        }



        private void SaveMeAs_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrEmpty(newText.Text))
            {
                MessageBox.Show("Plese type some text", "Unable to save this text", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            saveFileDialog1.InitialDirectory = observer.newPathFilesFolder;
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
            //var temp = new FileInfo(eventFile.FullPath);

            //if (temp.Attributes == FileAttributes.Directory)
            //{
            //    string newPath = $@"{Environment.CurrentDirectory}\Backup\{eventFile.Name}";

            //    if (!Directory.Exists(newPath))
            //    {
            //        Directory.CreateDirectory(newPath);
            //    }
            //}
            //else if (temp.Length != 0)
                CreateBackup(eventFile);
            Thread.Sleep(100);
            CreateBackupDirectorys(eventFile);

            

            //File.Copy(eventFile.FullPath, observer.newPathBackupFolder + $"{count}. {File.GetLastWriteTime(eventFile.FullPath):dd.MM.yyyy HH.mm.ss}.txt", true);
        }

        private void FileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs eventFile)
        {
            
            //FileInfo fileInfo = new FileInfo(eventFile.FullPath);

            //if (fileInfo.Attributes == FileAttributes.Directory)
            //{
            //    string newPath = $@"{Environment.CurrentDirectory}\Backup\{eventFile.Name}";

            //    if (!Directory.Exists(newPath))
            //    {
            //        Directory.CreateDirectory(newPath);
            //    }
            //}
            //else if (fileInfo.Length != 0)

            CreateBackup(eventFile);
            Thread.Sleep(100);

            CreateBackupDirectorys(eventFile);
        }

        private void CreateBackupDirectorys(FileSystemEventArgs eventFile)
        {
            //fileSystemWatcher1.Deleted -= FileSystemWatcher1_Deleted;
            string newDir = $@"{observer.PathBackupFoldersWithDate}{File.GetLastWriteTime(eventFile.FullPath):dd.MM.yyyy HH.mm.ss}";
            Directory.CreateDirectory(newDir);
            Thread.Sleep(100);
            string[] directorys = Directory.GetDirectories(observer.newPathBackupFolder);

            foreach (var dir in directorys)
            {
                DateTime date = Directory.GetLastWriteTime(dir);
                if (date < Directory.GetLastWriteTime(newDir))
                {
                    string[] files = Directory.GetFiles(dir);
                    foreach (var file in files)
                    {
                        DateTime time = Directory.GetLastWriteTime(file);
                        File.Copy(file, $@"{newDir}\{Path.GetFileNameWithoutExtension(file)}.txt", true);
                    }
                }
            }
        }

        private void CreateFolder_Click(object sender, EventArgs e)
        {
            GetPathToFiles();
            CheckFolders();
            newText.Enabled = true;
            SaveMeAs.Enabled = true;
 
        }

        private void SaveBackupChanges_Click(object sender, EventArgs e)
        {
            File.WriteAllText(saveFileDialog1.FileName, newText.Text);
            saveBackupLabel.BackColor = System.Drawing.Color.Red;
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
        private void CreateBackup(FileSystemEventArgs eventFile)
        {
            //string newDir = $@"{observer.newPathBackupFolder}{File.GetLastWriteTime(eventFile.FullPath):dd.MM.yyyy HH.mm.ss}";
            //Directory.CreateDirectory(newDir);
            //Thread.Sleep(10);
            //string dateTime = $@"{File.GetLastWriteTime(eventFile.FullPath):dd.MM.yyyy HH.mm.ss}";
            //string fileName = Path.GetFileNameWithoutExtension(eventFile.Name);
            //string nameBackup = $"{dateTime}-{fileName}.txt";
            //string subFolderAllBackups = $@"{observer.newPathBackupFolder}All Backups\";

            //string[] directorys = Directory.GetDirectories(observer.newPathBackupFolder);

            //foreach (var dir in directorys)
            //{
            //    DateTime date = Directory.GetLastWriteTime(dir);
            //    if (date < Directory.GetLastWriteTime(newDir))
            //    {
            //        string[] files = Directory.GetFiles(dir);
            //        foreach (var file in files)
            //        {
            //            DateTime time = Directory.GetLastWriteTime(file);
            //            File.Copy(file, $@"{newDir}\{Path.GetFileNameWithoutExtension(file)}.txt", true);
            //        }
            //    }
            //}

            string directory;
            string dateTime = $@"{File.GetLastWriteTime(eventFile.FullPath):dd.MM.yyyy HH.mm.ss}";
            string fileName = Path.GetFileNameWithoutExtension(eventFile.Name);
            string nameBackup = $"{dateTime}-{fileName}.txt";

            string subFolder = Path.GetDirectoryName(eventFile.Name);

            if (subFolder == "")
            {
                directory = $@"{observer.newPathBackupFolder}\{fileName}\";
            }
            else
            {
                directory = $@"{observer.newPathBackupFolder}\{subFolder}\{fileName}\";
            }

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string destFullPath = $@"{directory}\{nameBackup}";

            if (!File.Exists(destFullPath))
                File.Copy(eventFile.FullPath, destFullPath);
        }

        private void FileSystemWatcher1_Deleted(object sender, FileSystemEventArgs eventFile)
        {
            string fileName = Path.GetFileNameWithoutExtension(eventFile.Name);
            string directory = $@"{observer.newPathBackupFolder}{fileName}\";
            //DirectoryInfo directory1 = new DirectoryInfo(directory);
            bool fileEx = File.Exists($@"{observer.newPathFilesFolder}\{fileName}\{eventFile.Name}");
            if (!fileEx)
            {
                string[] files = Directory.GetFiles(directory);
                for (int i = 0; i < files.Length; i++)
                {
                    File.Delete(files[i]);



                    //File.Copy(files[i], $@"{directory}DELETED_{Path.GetFileName(files[i])}");
                    //string name = Path.GetFileName(files[i]);
                    //files[i] = name.Insert(0, "DELETED_");

                }
                Directory.Delete(directory);
            }
            bool eventFileEx = File.Exists(eventFile.FullPath);
            if (!eventFileEx)
            {
                RemoveAndRename(sender, eventFile);
            }
            //bool isTryAgain = false;
            //string nameFolder = "";

            //string backupPath = $@"{observer.newPathBackupFolder}\{e.Name}";
            //bool isExists = Directory.Exists(backupPath);

            //if (!isExists)
            //{
            //    isTryAgain = true;

            //    nameFolder = e.Name.Substring(0, e.Name.LastIndexOf('.'));
            //    backupPath = $@"{observer.newPathBackupFolder}\{nameFolder}";

            //    isExists = Directory.Exists(backupPath);
            //}

            //if (isExists)
            //{
            //    bool isContaintsSub = Directory.GetFileSystemEntries(backupPath).Any();

            //    if (isContaintsSub)
            //    {
            //        string dateTimeRemoved = DateTime.Now.ToString("yyyy.MM.dd-HH.mm.ss");
            //        dateTimeRemoved = $@"Removed_{dateTimeRemoved}_";

            //        if (isTryAgain)
            //            nameFolder = nameFolder.Insert(nameFolder.LastIndexOf('\\') + 1, dateTimeRemoved);
            //        else
            //            nameFolder = e.Name.Insert(e.Name.LastIndexOf('\\') + 1, dateTimeRemoved);

            //        string newBackupPath = $@"{observer.newPathBackupFolder}\{nameFolder}";

            //        Directory.Move(backupPath, newBackupPath);
            //    }
            //    else
            //        Directory.Delete(backupPath);
            //}
        }

        private void RemoveAndRename(object sender, FileSystemEventArgs eventFile)
        {
            (sender as FileSystemWatcher).EnableRaisingEvents = false;
            string backupDir = $@"{observer.PathBackupFoldersWithDate}";
            string[] dirs = Directory.GetDirectories(backupDir);
            foreach (var dir in dirs)
            {
                string[] allFiles = Directory.GetFiles(dir, $"*-{eventFile.Name.ToString()}");
                for (int i = 0; i < allFiles.Length; i++)
                {
                    string oneFileName = Path.GetFileName(allFiles[i]);
                    //if (oneFileName.Contains(eventFile.Name))
                    //{
                    string youDirName = Path.GetDirectoryName(allFiles[i]);
                    File.Copy(allFiles[i], $@"{youDirName}\DELETED_{Path.GetFileName(allFiles[i])}", true);

                    //allFiles[i] = $@"{youDirName}\DELETED_{Path.GetFileName(allFiles[i])}";
                    //MessageBox.Show(youDirName);
                    //File.Copy(allFiles[i], $@"{youDirName}\DELETED_{Path.GetFileName(allFiles[i])}", true);
                    //File.Delete(allFiles[i]);
                    //}
                }
            }
                    (sender as FileSystemWatcher).EnableRaisingEvents = true;
        }
    }
}
