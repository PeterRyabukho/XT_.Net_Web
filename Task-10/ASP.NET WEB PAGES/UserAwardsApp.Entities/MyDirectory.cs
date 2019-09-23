using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAwardsApp.Entities
{
    public static class MyDirectory
    {
        public static string CreateDirectory { get; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-06\";
        public static string UsersFile => $"{CreateDirectory}Users.txt";
        public static string AwardsFile => $"{CreateDirectory}Awards.txt";
        public static string AwardsOfUsersFile => $"{CreateDirectory}Awards of Users.txt";
        public static string ConfigFile => $"{CreateDirectory}Config.txt";
        public static string AccountsFile => $"{CreateDirectory}Account.txt";

        static MyDirectory()
        {
            if (!Directory.Exists(CreateDirectory))
            {
                Directory.CreateDirectory(CreateDirectory);
            }
            if (!File.Exists(UsersFile))
            {
                using (StreamWriter writer = new StreamWriter(UsersFile, true))
                {
                    writer.WriteLine("");
                }
            }
            if (!File.Exists(AwardsFile))
            {
                using (StreamWriter writer = new StreamWriter(AwardsFile, true))
                {
                    writer.WriteLine("");
                }
            }
            if (!File.Exists(AwardsOfUsersFile))
            {
                using (StreamWriter writer = new StreamWriter(AwardsOfUsersFile, true))
                {
                    writer.WriteLine("");
                }
            }
            if (!File.Exists(ConfigFile))
            {
                using (StreamWriter writer = new StreamWriter(ConfigFile, true))
                {
                    writer.WriteLine("");
                }
            }
            if (!File.Exists(AccountsFile))
            {
                using (StreamWriter writer = new StreamWriter(AccountsFile, true))
                {
                    writer.WriteLine("");
                }
            }
        }
        public static void Check()
        {

        }
        public static bool CheckOrCreateDirectoryAndFiles()
        {
            if (!Directory.Exists(CreateDirectory))
            {
                return true;
            }
            if (!File.Exists(UsersFile))
            {
                return true;
            }
            if (!File.Exists(AwardsFile))
            {
                return true;
            }
            if (!File.Exists(AwardsOfUsersFile))
            {
                return true;
            }
            if (!File.Exists(ConfigFile))
            {
                return true;
            }
            if (!File.Exists(AccountsFile))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
