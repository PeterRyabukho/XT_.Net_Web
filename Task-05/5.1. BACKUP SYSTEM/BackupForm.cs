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
using System.Diagnostics;

namespace _5._1.BACKUP_SYSTEM
{
    public partial class BackupForm : Form
    {
        Common common = new Common();

        public BackupForm()
        {
            InitializeComponent();
            label4.Text = "*You can restore any deleted backup file simply by clicking on it," + Environment.NewLine +
                        " then this file with the same name will be used as the main file";
            dateBackupList.SelectedIndexChanged += DateList_SelectedIndexChanged;
            filesBackupList.SelectedIndexChanged += FilesBackupList_SelectedIndexChanged;
        }

        private void GetBackupDateList()
        {

            string[] directorys = Directory.GetDirectories(common.PathBackupFoldersWithDate);
            for (int i = 0; i < directorys.Length; i++)
            {
                DirectoryInfo directory = new DirectoryInfo(directorys[i]);
                Path.GetDirectoryName(directorys[i]);
                dateBackupList.Items.Add(directory.Name);
            }

        }

        private void DateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDate = dateBackupList?.SelectedItem?.ToString(); //if y click empty list - "NullRef Exep", so thats why "?." here
            filesBackupList.Items.Clear();

            if (Directory.Exists($@"{common.PathBackupFoldersWithDate}{selectedDate}"))
            {
                string[] files = Directory.GetFiles($@"{common.PathBackupFoldersWithDate}{selectedDate}");
                for (int j = 0; j < files.Length; j++)
                {
                    filesBackupList.Items.Add(Path.GetFileNameWithoutExtension(files[j]));
                }
            }
            else
            {
                MessageBox.Show("Directory deleted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateBackupList.Items.Clear();

                return;
            }
        }
        private bool toFind = false;

        private void FilesBackupList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedItem = filesBackupList?.SelectedItem?.ToString();


            if (selectedItem.Contains("DELETED_"))
            {
                ShowFunctionToRestoreDELETEDBackup(selectedItem);

            }
            else
            {
                ShowTextBackupsThatNotDELETED(selectedItem);
            }
        }
        private bool toDelete = false;
        private void ShowFunctionToRestoreDELETEDBackup(string selectedItem)
        {
            string[] directorys = Directory.GetDirectories(common.PathBackupFoldersWithDate);

            foreach (var dir in directorys)
            {
                string[] deletedFiles = Directory.GetFiles(dir, "DELETED_*");
                foreach (var backupfile in deletedFiles)
                {
                    string serchFile = Path.GetFileNameWithoutExtension(backupfile);

                    if (serchFile == selectedItem && !toFind)
                    {
                        backupText.Text = File.ReadAllText(backupfile);
                        var result = MessageBox.Show("Restore the original file based on this backup?", "File restore", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            serchFile = serchFile.Substring(28);
                            File.Copy(backupfile, $@"{common.newPathFilesFolder}\{serchFile}.txt", true);
                            MessageBox.Show("Recovery is complete!" + Environment.NewLine + $"The file was restored with changes to the specified date" + Environment.NewLine +
                                $"{File.GetLastWriteTime(backupfile)}", "Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            toDelete = true;

                            //filesBackupList.Items.Clear();
                            ShowTextBackupsThatNotDELETED(selectedItem);
                        }
                        else
                        {
                            dateBackupList.Items.Clear();
                            GetBackupDateList();
                        }
                        toFind = true;
                    }
                    if (toDelete)
                    {
                        File.Delete(backupfile);
                        
                    }
                }
            }
        }

        private void ShowTextBackupsThatNotDELETED(string selectedItem)
        {
            string[] directorys = Directory.GetDirectories(common.PathBackupFoldersWithDate);

            foreach (var datadir in directorys)
            {
                string[] files = Directory.GetFiles(datadir);

                foreach (var backupfile in files)
                {
                    if (File.Exists(backupfile))
                    {
                        string serchFile = Path.GetFileNameWithoutExtension(backupfile);

                        if (serchFile == selectedItem)
                        {
                            backupText.Text = File.ReadAllText(backupfile);
                        }
                    }
                    else
                    {
                        MessageBox.Show("File deleted!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        filesBackupList.Items.Clear();

                    }
                }
            }
        }

        private void ShowBackupDates_Click(object sender, EventArgs e)
        {
            dateBackupList.Items.Clear();
            
            GetBackupDateList();
        }

        private void MenuButton_Click(object sender, EventArgs e)
        {
            BackupForm form = new BackupForm();
            form.Close();
            MainForm form1 = new MainForm();
            form1.Show();
           
        }

        private void BackupFolders_Click(object sender, EventArgs e)
        {
            Process.Start(common.PathBackupFoldersWithDate);
        }

        //private void CreateMainFolders_Click(object sender, EventArgs e)
        //{
        //    MonitoringForm monitoring = new MonitoringForm();
        //    monitoring.CreateFolder_Click(sender, e);
        //}
    }
}
