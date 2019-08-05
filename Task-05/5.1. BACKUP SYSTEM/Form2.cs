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
    public partial class Form2 : Form
    {
        Observer observer = new Observer();
        public Form2()
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
                MessageBox.Show("The directory exists!");
            }
            else
            {
                Directory.CreateDirectory(observer.newPathBackupFolder);
                Directory.CreateDirectory(observer.newPathFilesFolder);
                MessageBox.Show($"Folders creating complite:{Environment.NewLine}{ observer.newPathBackupFolder}{Environment.NewLine}{observer.newPathFilesFolder}");
            }
            fileSystemWatcher1.Path = observer.newPathFilesFolder;
        }

        private void CreateBackup(FileSystemEventArgs eventFile)
        {
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
                observer.Save(saveFileDialog1.FileName);

                MessageBox.Show("New file written!", "Complite", MessageBoxButtons.OK);
            }
            
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
        }

        private void SaveBackupChanges_Click(object sender, EventArgs e)
        {
            count++;
            File.WriteAllText(saveFileDialog1.FileName, newText.Text);
        }

        private void GoToMenuButton_Click(object sender, EventArgs e)
        {
            MainForm mainform = new MainForm();
            mainform.Show();
            this.Close();
        }
    }
}
