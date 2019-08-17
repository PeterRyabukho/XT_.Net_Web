using System;
using System.Collections.Generic;
using System.Text;
using Entities.DesignPatterns;
using System.IO;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;

namespace DAL.DesignPatterns
{
    public class DAL_File_User : IKeepUsers
    {
        //private static string createDirectory { get; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-06\";
        //private static string pathToFile { get; } = $"{createDirectory}Users.txt";

        public Dictionary<Guid, User> usersDictionary { get; set; }

        public DAL_File_User()
        {
            //if (!Directory.Exists(createDirectory))
            //{
            //    Directory.CreateDirectory(createDirectory);
            //}
            usersDictionary = new Dictionary<Guid, User>();
        }

        public bool SerializerJsonUsers()
        {
            AllUsers user = new AllUsers();
            foreach (var item in usersDictionary.Values)
            {
                user.Users.Add(item);
            }
            if (user.Users.Count == 0)
                return false;
            else
            {
                //award.Awards = GetAllAwards().ToList();
                string usersJson = JsonConvert.SerializeObject(user.Users, Formatting.Indented);
                Thread.Sleep(50);
                File.WriteAllText(MyDirectory.UsersFile, usersJson, Encoding.Default);
                return true;
            }
        }

        public bool DeSerializerJsonUsers()
        {
            List<User> users = JsonConvert.DeserializeObject<List<User>>(File.ReadAllText(MyDirectory.UsersFile));
            if (users == null)
                return false;
            foreach (var user in users)
            {
                usersDictionary.Add(user.ID, user);
            }
            return true;
        }

        public User GetUserByID(Guid ID)
        {
            return usersDictionary.ContainsKey(ID) ? usersDictionary[ID] : null;
        }

        public bool AddUser(User user)
        {
            if (usersDictionary.Values.Any(userName => userName.Name == user.Name) && GetUserByID(user.ID) != null)
            {
                return false;
            }

            //users.Add(user);
            usersDictionary.Add(user.ID, user);
            return true;
        }

        public bool RemoveUser(Guid ID)
        {
            if (usersDictionary.ContainsKey(ID))
            {
                usersDictionary.Remove(ID);
                return true;
            }
            else
            {
                return false;
            }
            //foreach (var whantToRemoveThisUser in usersDictionary.Values)
            //{
            //    if (whantToRemoveThisUser.Name == nameToFind)
            //    {
            //        usersDictionary.Remove(whantToRemoveThisUser.ID);
            //        break;
            //    }
            //}
        }

        public ICollection<User> GetAllUsers()
        {
            return usersDictionary.Values.ToList();
            //var stringUsers = new List<string>();
            //foreach (var item in users)
            //{
            //    stringUsers.Add(item.ToString());
            //}
            //return stringUsers;
        }

        public bool SetAllUsers(IEnumerable<User> users)
        {
            try
            {
                usersDictionary.Clear();
                foreach (var user in users)
                {
                    usersDictionary.Add(user.ID, user);
                }

                return true;
            }
            catch
            {
                return false;
            }
        }


        //public bool AddUser(User user)
        //{
        //    //if (file.Any(userName => userName.Name == user.Name))
        //    //{
        //    //    return false;
        //    //}


        //    if (File.Exists(pathToFile))
        //    {
        //        using(StreamWriter writer = new StreamWriter(pathToFile, true, Encoding.Default))
        //        {
        //            writer.WriteLine(user.ToString());
        //        }
        //    }
        //    else
        //        File.WriteAllText(pathToFile, user.ToString(), Encoding.Default);
        //    return true;
        //}

        //public ICollection<string> GetAllUsers()
        //{
        //    var users = new List<string>();
        //    Stream fileStream = new FileStream(pathToFile, FileMode.Open, FileAccess.Read);
        //    using(StreamReader reader = new StreamReader(fileStream, Encoding.Default))
        //    {
        //        string newLine = string.Empty;
        //        while (reader.Peek() != -1)
        //        {
        //            newLine = reader.ReadLine();
        //            users.Add(newLine);
        //        }
        //    }
        //    fileStream.Close();

        //    return users;
        //    //users.Add(File.ReadLines(pathToFile));
        //}

        //public void RemoveUser(string nameToFind)
        //{
        //    //var users = new List<string>();
        //    //Stream fileStream = new FileStream(pathToFile, FileMode.Open, FileAccess.Read);
        //    //using (StreamReader reader = new StreamReader(fileStream, Encoding.Default))
        //    //{
        //    //    string newLine = string.Empty;
        //    //    while (reader.Peek() != -1)
        //    //    {
        //    //        newLine = reader.ReadLine();
        //    //        users.Add(newLine);
        //    //    }
        //    //}
        //    //fileStream.Close();

        //    ////users.Contains(nameToFind);

        //    //users.ToArray();
        //    //var selectedUsers = from user in users
        //    //                    let name = user.ToArray()
        //    //                    let nameFind = name.ToString()
        //    //                    where nameFind.Contains(nameToFind)
        //    //                    select nameFind;
        //    //foreach (var item in selectedUsers)
        //    //{
        //    //    users.Remove(item);
        //    //}

        //    var removeRowWithNameToFind = File.ReadAllLines(pathToFile, Encoding.Default).
        //                                  Where(name => !name.Contains(nameToFind));
        //    Thread.Sleep(50);
        //    File.WriteAllLines(pathToFile, removeRowWithNameToFind, Encoding.Default);
        //}
    }
}
