using Entities.DesignPatterns;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.DesignPatterns
{
    public class DAL_Memory_User: IKeepUsers
    {
        public Dictionary<Guid,User> usersDictionary { get; set; }

        public DAL_Memory_User()
        {
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

            usersDictionary.Add(user.ID, user);
            return true;
        }

        public ICollection<User> GetAllUsers()
        {
            return usersDictionary.Values.ToList();
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
