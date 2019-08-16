using System;
using System.Collections.Generic;
using System.Text;
using Entities.DesignPatterns;
using System.IO;
using System.Linq;
using System.Threading;

namespace DAL.DesignPatterns
{
    public class DAL_File_User //: IKeepUsers
    {
        private static string createDirectory { get; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-06\";
        private static string pathToFile { get; } = $"{createDirectory}Users.txt";
        static DAL_File_User()
        {
            Directory.CreateDirectory(createDirectory);
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
                File.WriteAllText(pathToFile, user.ToString(), Encoding.Default);
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
            //var users = new List<string>();
            //Stream fileStream = new FileStream(pathToFile, FileMode.Open, FileAccess.Read);
            //using (StreamReader reader = new StreamReader(fileStream, Encoding.Default))
            //{
            //    string newLine = string.Empty;
            //    while (reader.Peek() != -1)
            //    {
            //        newLine = reader.ReadLine();
            //        users.Add(newLine);
            //    }
            //}
            //fileStream.Close();

            ////users.Contains(nameToFind);

            //users.ToArray();
            //var selectedUsers = from user in users
            //                    let name = user.ToArray()
            //                    let nameFind = name.ToString()
            //                    where nameFind.Contains(nameToFind)
            //                    select nameFind;
            //foreach (var item in selectedUsers)
            //{
            //    users.Remove(item);
            //}

            var removeRowWithNameToFind = File.ReadAllLines(pathToFile, Encoding.Default).
                                          Where(name => !name.Contains(nameToFind));
            Thread.Sleep(50);
            File.WriteAllLines(pathToFile, removeRowWithNameToFind, Encoding.Default);
        }
    }
}
