using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Threading;

namespace _5._1.BACKUP_SYSTEM
{
    class Observer
    {
        Common common = new Common();

        public void CreateBackupDirectorys(object sender, FileSystemEventArgs eventFile)
        {
            Thread.Sleep(50);
            //(sender as FileSystemWatcher).EnableRaisingEvents = false;
            string newDir = $@"{common.PathBackupFoldersWithDate}{File.GetLastWriteTime(eventFile.FullPath):dd.MM.yyyy HH.mm.ss}";
            Directory.CreateDirectory(newDir);
            Thread.Sleep(5);
            string[] directorys = Directory.GetDirectories(common.newPathBackupFolder);

            foreach (var dir in directorys)
            {
                string[] files = Directory.GetFiles(dir);

                foreach (var file in files)
                {
                    DateTime date = File.GetLastWriteTime(file);
                    if (date <= Directory.GetCreationTime(newDir))
                    {
                    
                        //DateTime time = Directory.GetLastWriteTime(file);
                        File.Copy(file, $@"{newDir}\{Path.GetFileNameWithoutExtension(file)}.txt", true);
                    }
                }
            }
            //(sender as FileSystemWatcher).EnableRaisingEvents = false;
        }

        public void CreateBackup(object sender, FileSystemEventArgs eventFile)
        {
            //(sender as FileSystemWatcher).EnableRaisingEvents = false;
            Thread.Sleep(50);
            string directory;
            string dateTime = $@"{File.GetLastWriteTime(eventFile.FullPath):dd.MM.yyyy HH.mm.ss}";
            string fileName = Path.GetFileNameWithoutExtension(eventFile.Name);
            string nameBackup = $"{dateTime}-{fileName}.txt";

            string subFolder = Path.GetDirectoryName(eventFile.Name);

            if (subFolder == "")
            {
                directory = $@"{common.newPathBackupFolder}\{fileName}\";
            }
            else
            {
                directory = $@"{common.newPathBackupFolder}\{subFolder}\{fileName}\";
            }

            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }

            string destFullPath = $@"{directory}\{nameBackup}";

            if (!File.Exists(destFullPath))
            {
                File.Copy(eventFile.FullPath, destFullPath);
            }
            //(sender as FileSystemWatcher).EnableRaisingEvents = true;
        }

        public void DeleteEventFileBackupsInFolder(object sender, FileSystemEventArgs eventFile)
        {
            //(sender as FileSystemWatcher).EnableRaisingEvents = false;
            string fileName = Path.GetFileNameWithoutExtension(eventFile.Name);
            string directory = $@"{common.newPathBackupFolder}{fileName}\";

            bool fileEx = File.Exists($@"{common.newPathFilesFolder}\{fileName}\{eventFile.Name}");
            if (!fileEx)
            {
                string[] files = Directory.GetFiles(directory);
                for (int i = 0; i < files.Length; i++)
                {
                    File.Delete(files[i]);
                }
                Directory.Delete(directory);
            }
            //(sender as FileSystemWatcher).EnableRaisingEvents = true;
        }

        public void RemoveAndRenameFilesInDataDir(object sender, FileSystemEventArgs eventFile)
        {
            (sender as FileSystemWatcher).EnableRaisingEvents = false;

            string backupDir = $@"{common.PathBackupFoldersWithDate}";
            string[] dirs = Directory.GetDirectories(backupDir);

            foreach (var dir in dirs)
            {
                string[] allFiles = Directory.GetFiles(dir, $"*-{eventFile.Name.ToString()}");
                for (int i = 0; i < allFiles.Length; i++)
                {
                    string oneFileName = Path.GetFileName(allFiles[i]);
                    string youDirName = Path.GetDirectoryName(allFiles[i]);

                    File.Copy(allFiles[i], $@"{youDirName}\DELETED_{Path.GetFileName(allFiles[i])}", true);
                    File.Delete(allFiles[i]);
                }
            }

            (sender as FileSystemWatcher).EnableRaisingEvents = true;
        }

        //public void Save(string fileName)
        //{
        //    using (StreamWriter writer = new StreamWriter(fileName))
        //    {
        //        writer.WriteLine(Description);
        //    }
        //}

    }
}
