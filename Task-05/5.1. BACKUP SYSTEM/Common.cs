using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _5._1.BACKUP_SYSTEM
{
    class Common
    {
        public string newPathBackupFolder { get; set; }
        public string newPathFilesFolder { get; set; }
        public string PathBackupFoldersWithDate { get; set; }

        public Common()
        {
            newPathBackupFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-05\Backup folder\Backups for each file\";
            newPathFilesFolder = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-05\Files folder";
            PathBackupFoldersWithDate = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-05\Backup folder\Date Backup Folders\";
        }

        public void CheckFolders()
        {
            bool directoryExists1 = Directory.Exists(newPathBackupFolder);
            bool directoryExists2 = Directory.Exists(newPathFilesFolder);
            if (directoryExists1 && directoryExists2)
            {
                MessageBox.Show("Directorys already exists!", "Directorys OK!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                Directory.CreateDirectory(newPathBackupFolder);
                Directory.CreateDirectory(newPathFilesFolder);
                MessageBox.Show($"Folders creating complite:{Environment.NewLine}{ newPathBackupFolder}{Environment.NewLine}{newPathFilesFolder}",
                                "Folders created!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            
        }
    }
}
