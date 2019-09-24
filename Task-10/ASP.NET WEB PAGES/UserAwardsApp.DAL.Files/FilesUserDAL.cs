using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserAwardsApp.DAL.Abstract;
using UserAwardsApp.Entities;

namespace UserAwardsApp.DAL.Files
{
    public class FilesUserDAL : IUserDAL
    {
        public static Dictionary<Guid, User> usersDictionary { get; set; }

        static FilesUserDAL()
        {
            usersDictionary = new Dictionary<Guid, User>();
            DeSerializerJsonUsers();
        }

        public bool SerializerJsonUsers()
        {
            if (!string.IsNullOrEmpty(MyDirectory.UsersFile) && !string.IsNullOrWhiteSpace(MyDirectory.UsersFile))
            {
                var allUsers = from user in usersDictionary.Values
                               select new
                               {
                                   user.ID,
                                   user.Name,
                                   user.DateOfBirth,
                                   user.Age,
                                   user.Image
                                   
                               };

                var userToJson = new { Users = allUsers };

                string userJson = JsonConvert.SerializeObject(userToJson, Formatting.Indented);

                File.WriteAllText(MyDirectory.UsersFile, userJson);
                return true;
            }
            return false;
        }

        public static bool DeSerializerJsonUsers()
        {
            if (!string.IsNullOrEmpty(MyDirectory.UsersFile) && File.Exists(MyDirectory.UsersFile))
            {
                string data = File.ReadAllText(MyDirectory.UsersFile);

                var usersList = new { Users = new List<User>() };

                usersList = JsonConvert.DeserializeAnonymousType(data, usersList);

                if (usersList.Users == null)
                {
                    return false;
                }

                foreach (User user in usersList.Users)
                {

                    usersDictionary.Add(user.ID, user);
                }
                return true;
            }
            return false;
        }


        public User GetUserByID(Guid ID)
        {
            return usersDictionary.ContainsKey(ID) ? usersDictionary[ID] : null;
        }

        public User AddUser(User user)
        {
                //if (usersDictionary.Values.Any(userName => userName.Name == user.Name) && GetUserByID(user.ID) != null)
                //{
                //return false;
                //}

                usersDictionary.Add(user.ID, user);
                SerializerJsonUsers();

                return user;
        }

        public bool RemoveUser(Guid ID)
        {
            if (usersDictionary.ContainsKey(ID))
            {
                usersDictionary.Remove(ID);
                SerializerJsonUsers();

                return true;
            }
            else
            {
                return false;
            }
        }

        public IEnumerable<User> GetAllUsers()
        {
            return usersDictionary.Values.ToList();
        }

        public bool EditUser(Guid ID, string Name, DateTime dOB)
        {
            if (usersDictionary.ContainsKey(ID))
            {
                var myCol = usersDictionary.TryGetValue(ID, out User userToEdit);

                userToEdit.Name = Name;
                userToEdit.DateOfBirth = dOB;
                SerializerJsonUsers();

                return true;
            }
            else
                return false;
        }
    }
}
