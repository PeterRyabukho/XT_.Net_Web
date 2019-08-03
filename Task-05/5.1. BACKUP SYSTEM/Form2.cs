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
            observer.newPathBackupFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-05\Beckup folder\";
            observer.newPathFilesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-05\Files folder";
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
            File.Copy(eventFile.FullPath, observer.newPathBackupFolder + $"{count}. {File.GetLastWriteTime(eventFile.FullPath):dd.MM.yyyy HH.mm.ss}.txt", true);
            
        }

        private void FileSystemWatcher1_Created(object sender, System.IO.FileSystemEventArgs eventFile)
        {
            File.Copy(eventFile.FullPath, Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-05\" + eventFile.Name, true);
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
