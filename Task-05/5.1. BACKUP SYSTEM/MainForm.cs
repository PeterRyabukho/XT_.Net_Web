using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5._1.BACKUP_SYSTEM
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void ObserverButton_Click(object sender, EventArgs e)
        {
            MonitoringForm form2 = new MonitoringForm();
            MainForm mainForm = new MainForm();
            form2.Show();
            mainForm.Close();
        }

        private void BackupButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            BackupForm form3 = new BackupForm();
            form3.Show();
            mainForm.Close();
        }
    }
}
