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
        Observer observer = new Observer(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-05\Beckup folder\", Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-05\Files folder");
        public Form3()
        {
            InitializeComponent();
            dateBackupList.SelectedIndexChanged += DateList_SelectedIndexChanged;
        }

        private void GetBackupDateList()
        {
            string[] files = Directory.GetFiles(observer.newPathBackupFolder);
            for (int i = 0; i < files.Length; i++)
            {
                DateTime backupDate = File.GetLastWriteTime(files[i]);
                dateBackupList.Items.Add($"{i}. {backupDate:dd.MM.yyyy HH.mm.ss}");

            }
        }

        private void DateList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDate = dateBackupList.SelectedItem.ToString();
            string showDate = $@"{observer.newPathBackupFolder}{selectedDate}.txt";
            backupText.Text = File.ReadAllText(showDate);

            //catch
            //{
            //    MessageBox.Show("Someone specially modified this backup file!");
            //}
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
    }
}
