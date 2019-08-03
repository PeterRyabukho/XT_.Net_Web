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
            Form2 form2 = new Form2();
            MainForm mainForm = new MainForm();
            form2.Show();
            mainForm.Close();
        }

        private void BackupButton_Click(object sender, EventArgs e)
        {
            MainForm mainForm = new MainForm();
            Form3 form3 = new Form3();
            form3.Show();
            mainForm.Close();
        }
    }
}
