using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading;

namespace Entities.DesignPatterns
{
    public static class MyDirectory
    {
        public static string CreateDirectory { get; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-06\";
        public static string UsersFile  => $"{CreateDirectory}Users.txt";
        public static string AwardsFile => $"{CreateDirectory}Awards.txt";
        public static string AwardsOfUsersFile => $"{CreateDirectory}Awards of Users.txt";
        public static string ConfigFile => $"{CreateDirectory}Config.txt";

        static MyDirectory()
        {
            //CreateDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-06\";
            if (!Directory.Exists(CreateDirectory))
            {
                Directory.CreateDirectory(CreateDirectory);
            }
            if (!File.Exists(UsersFile))
            {
                File.Create(UsersFile);
            }
            if (!File.Exists(AwardsFile))
            {
                File.Create(AwardsFile);
            }
            if (!File.Exists(AwardsOfUsersFile))
            {
                File.Create(AwardsOfUsersFile);
            }
            if (!File.Exists(ConfigFile))
            {
                File.Create(ConfigFile);
            }
        }
        public static void Check()
        {

        }
        public static bool CheckOrCreateDirectoryAndFiles()
        {
            if (!Directory.Exists(CreateDirectory))
            {
                Directory.CreateDirectory(CreateDirectory);
                return true;
            }
            if (!File.Exists(UsersFile))
            {
                File.Create(UsersFile);
                return true;
            }
            if (!File.Exists(AwardsFile))
            {
                File.Create(AwardsFile);
                return true;
            }
            if (!File.Exists(AwardsOfUsersFile))
            {
                File.Create(AwardsOfUsersFile);
                return true;
            }
            if (!File.Exists(ConfigFile))
            {
                File.Create(ConfigFile);
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
