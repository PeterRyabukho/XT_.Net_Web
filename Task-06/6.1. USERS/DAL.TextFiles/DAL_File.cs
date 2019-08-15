using System;
using System.Collections.Generic;
using System.Text;
using Entities.DesignPatterns;
using System.IO;
using System.Linq;

namespace DAL.DesignPatterns
{
    public class DAL_File : IKeepUsers
    {
        private static FileInfo file { get; set; }
        private static string createDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-06\";
        private static string pathToFile = $"{createDirectory}Users.txt";
        static DAL_File()
        {
            Directory.CreateDirectory(createDirectory);
            
            file = new FileInfo(pathToFile);
        }
        public bool AddUser(User user)
        {
            //if (file.Any(userName => userName.Name == user.Name))
            //{
            //    return false;
            //}

 
            if (File.Exists(pathToFile))
            {
                using(StreamWriter writer = new StreamWriter(pathToFile, true, Encoding.Default))
                {
                    writer.WriteLine(user.ToString());
                }
            }
            else
                File.WriteAllText(pathToFile, user.ToString());
            return true;
        }

        public ICollection<string> GetAllUsers()
        {
            var users = new List<string>();
            Stream fileStream = new FileStream(pathToFile, FileMode.Open, FileAccess.Read);
            using(StreamReader reader = new StreamReader(fileStream, Encoding.Default))
            {
                string newLine = string.Empty;
                while (reader.Peek() != -1)
                {
                    newLine = reader.ReadLine();
                    users.Add(newLine);
                }
            }
            fileStream.Close();

            return users;
            //users.Add(File.ReadLines(pathToFile));
        }

        public void RemoveUser(string nameToFind)
        {
            throw new NotImplementedException();
        }
    }
}
