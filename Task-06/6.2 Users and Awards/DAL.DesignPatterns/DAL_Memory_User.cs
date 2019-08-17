using Entities.DesignPatterns;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.DesignPatterns
{
    public class DAL_Memory_User: IKeepUsers
    {
        //private static Guid ID { get; set; }
        public Dictionary<Guid,User> usersDictionary { get; set; }

        //private static List<User> users { get; set; }

        public DAL_Memory_User()
        {
            //users = new List<User>();
            usersDictionary = new Dictionary<Guid, User>();
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

        public bool SerializerJsonUsers()
        {
            throw new NotImplementedException();
        }

        public bool DeSerializerJsonUsers()
        {
            throw new NotImplementedException();
        }
    }
}
