using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _5._1.BACKUP_SYSTEM
{
    class Observer
    {
        public string selectedFolder { get; set; }
        public string saveNewFileName { get ; set; }
        public string NewPathBackupFolder;
        public string newPathBackupFolder { get { return NewPathBackupFolder; } set { NewPathBackupFolder = value; } }
    }
}
