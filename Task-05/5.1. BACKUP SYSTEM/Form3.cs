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

namespace _5._1.BACKUP_SYSTEM
{
    public partial class Form3 : Form
    {
        Observer observer = new Observer(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-05\Backup folder\", 
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-05\Files folder",
            Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-05\Backup folder\Date Backup Folders\");

        public Form3()
        {
            InitializeComponent();
            dateBackupList.SelectedIndexChanged += DateList_SelectedIndexChanged;
            filesBackupList.SelectedIndexChanged += FilesBackupList_SelectedIndexChanged;
        }

        private void GetBackupDateList()
        {
            string[] directorys = Directory.GetDirectories(observer.PathBackupFoldersWithDate);
            for (int i = 0; i < directorys.Length; i++)
            {
                DirectoryInfo directory = new DirectoryInfo(directorys[i]);
                Path.GetDirectoryName(directorys[i]);
                dateBackupList.Items.Add(directory.Name);
            }
            //string[] files = Directory.GetFiles(observer.newPathBackupFolder);
            //for (int i = 0; i < files.Length; i++)
            //{
            //    DateTime backupDate = File.GetLastWriteTime(files[i]);
            //    dateBackupList.Items.Add($"{i}. {backupDate:dd.MM.yyyy HH.mm.ss}");
            //}
        }

        private void DateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            filesBackupList.Items.Clear();
            string selectedDate = dateBackupList.SelectedItem.ToString();

            string[] files = Directory.GetFiles($@"{observer.PathBackupFoldersWithDate}{selectedDate}");
            for (int j = 0; j < files.Length; j++)
            {
                FileInfo fileInfo = new FileInfo(files[j]);
                filesBackupList.Items.Add(Path.GetFileNameWithoutExtension(files[j]));
            }

            //string[] directorys = Directory.GetDirectories(observer.PathBackupFoldersWithDate);
            //for (int i = 0; i < directorys.Length; i++)
            //{
            //    DirectoryInfo directory = new DirectoryInfo(directorys[i]);
            //    string thisDate = Path.GetDirectoryName(directorys[i]);
            //    if(selectedDate == thisDate)
            //    {
            //        string[] files = Directory.GetFiles(observer.PathBackupFoldersWithDate);
            //        for (int j = 0; j < files.Length; j++)
            //        {
            //            FileInfo fileInfo = new FileInfo(files[j]);
            //            filesBackupList.Items.Add(fileInfo.Name);
            //        }
            //    }
            //}


            //string showDate = $@"{observer.newPathBackupFolder}{selectedDate}.txt";
            //backupText.Text = File.ReadAllText(showDate);

            //catch
            //{
            //    MessageBox.Show("Someone specially modified this backup file!");
            //}
        }
        private void FilesBackupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDate = dateBackupList.SelectedItem.ToString();
            //string[] directorys = Directory.GetDirectories(observer.PathBackupFoldersWithDate);
            //foreach (var dir in directorys)
            //{
            //    string[] files = Directory.GetFiles(dir);
            //    foreach (var file in files)
            //    {
            //        string serchFile = Path.GetFileNameWithoutExtension(file);
            //        //FileInfo fileInfo = new FileInfo(file);
            //        if (serchFile == selectedDate)
            //        {
            //            backupText.Text = File.ReadAllText(file);
            //        }
            //    }
            //}

            string serchFolder="";
            
            string[] directorys = Directory.GetDirectories(observer.PathBackupFoldersWithDate);
            foreach (var dir in directorys)
            {
                DirectoryInfo directory = new DirectoryInfo(dir);
                serchFolder = directory.Name;
                string showDate = $@"{observer.PathBackupFoldersWithDate}{serchFolder}\{selectedDate}.txt";
                if (File.Exists(showDate))
                {
                    backupText.Text = File.ReadAllText(showDate);
                }
            }
        }

        private void ShowBackupDates_Click(object sender, EventArgs e)
        {
            GetBackupDateList();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            MainForm form1 = new MainForm();
            form1.Show();
            this.Close();
        }

        private void BackupFolders_Click(object sender, EventArgs e)
        {
            DirectoryInfo directory = new DirectoryInfo(observer.newPathBackupFolder);
        }


    }
}
