using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _5._1.BACKUP_SYSTEM
{
    class Observer
    {
        public string Description { get; set; }
        public string newPathBackupFolder { get; set; }
        public string newPathFilesFolder { get; set; }
        public string PathBackupFoldersWithDate { get; set; }

        public Observer()
        {
            newPathBackupFolder = "";
            newPathFilesFolder = "";
            PathBackupFoldersWithDate = "";
        }
        public Observer(string newPathBackupFolder, string newPathFilesFolder, string PathBackupFoldersWithDate)
        {
            this.newPathFilesFolder = newPathFilesFolder;
            this.newPathBackupFolder = newPathBackupFolder;
            this.PathBackupFoldersWithDate = PathBackupFoldersWithDate;
        }




        public void Save(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                writer.WriteLine(Description);
            }
        }

    }
}
