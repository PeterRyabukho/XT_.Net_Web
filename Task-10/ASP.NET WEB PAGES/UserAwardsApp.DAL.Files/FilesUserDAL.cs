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
        }

        public ICollection<User> GetAllUsers()
        {
            return usersDictionary.Values.ToList();
        }
    }

}
