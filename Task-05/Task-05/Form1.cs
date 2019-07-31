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

namespace Task_05
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            string[] files = Directory.GetFiles(beckupFolder, $"#{count}*");
            for (int i = 0; i < files.Length; i++)
            {
                DateTime beckupDate = File.GetLastWriteTime(files[i]);
                backupDate.Items.Add($"{count}. {beckupDate}");
                
            }

            backupDate.SelectedIndex = 0;

        }

        private int count = 1;
        private string beckupFolder = @"D:\Users\cam\mydocs\Files for Task-05\Beckup Files\";
        private void FileSystemWatcher1_Changed(object sender, FileSystemEventArgs eventFile)
        {
            File.Replace(eventFile.FullPath, beckupFolder + eventFile.Name, beckupFolder + $"#{count}"+eventFile.Name);
            count++;
        }

        private void FileSystemWatcher1_Created(object sender, FileSystemEventArgs eventFile)
        {
            File.Copy(eventFile.FullPath, beckupFolder + eventFile.Name, true);
        }

        private string selectedFolder = "";
        private string saveNewFileName;
        private void Folder_Click(object sender, EventArgs e)
        {
            folderBrowserDialog1.SelectedPath = selectedFolder;
            DialogResult result = folderBrowserDialog1.ShowDialog();
            if(result==DialogResult.OK)
            {
                selectedFolder = folderBrowserDialog1.SelectedPath;
            }
        }

        private void SaveNewText_Click(object sender, EventArgs e)
        {
            if(String.IsNullOrEmpty(newText.Text))
            {
                MessageBox.Show("Plese type some text", "Unable to save this text", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            saveFileDialog1.InitialDirectory = selectedFolder;
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.FileName = "";
            DialogResult result = saveFileDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                saveNewFileName = selectedFolder+ saveFileDialog1.FileName;
                using(StreamWriter writer = new StreamWriter(saveNewFileName))
                {
                    writer.WriteLine(newText.Text);
                }
                MessageBox.Show("New file written!", "Complite", MessageBoxButtons.OK);
            }
            count = 1;
        }

        private void SaveChanges_Click(object sender, EventArgs e)
        {
            File.WriteAllText(saveNewFileName, newText.Text);
        }
    }
}
