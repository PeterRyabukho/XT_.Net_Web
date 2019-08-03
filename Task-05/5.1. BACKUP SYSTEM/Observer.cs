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
        public string selectedFolder { get; set; }
        public string Description { get; set; }
        public string saveNewFileName { get ; set; }
        public string newPathBackupFolder { get; set; }
        public string newPathFilesFolder { get; set; }

        public Observer()
        {
            newPathBackupFolder = "";
            newPathFilesFolder = "";
        }
        public Observer(string newPathBackupFolder, string newPathFilesFolder)
        {
            this.newPathFilesFolder = newPathFilesFolder;
            this.newPathBackupFolder = newPathBackupFolder;
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
