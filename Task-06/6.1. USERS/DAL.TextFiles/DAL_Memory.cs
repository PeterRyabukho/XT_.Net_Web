using Entities.DesignPatterns;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace DAL.DesignPatterns
{
    public class DAL_Memory: IKeepUsers
    {
        //private static Guid ID { get; set; }
        //private static Dictionary<Guid,User> usersDic { get; set; }

        private static List<User> users { get; set; }

        static DAL_Memory()
        {
            users = new List<User>();

            //ID = Guid.NewGuid();
            //usersDic = new Dictionary<Guid, User>();
        }

        //public static bool AddUserInMemory(User user)
        //{
        //    if(users.Any(userName=>userName.Name == user.Name))
        //    {
        //        return false;
        //    }
        //    users.Add(user);
        //    return true;
        //}

        //public static ICollection<User> GetAllUsersInMemory()
        //{
        //    return users;
        //}

        public bool AddUser(User user)
        {
            if (users.Any(userName => userName.Name == user.Name))
            {
                return false;
            }

            users.Add(user);
            return true;
        }

        public void RemoveUser(string nameToFind)
        {
            foreach (var item in users)
            {
                if(item.Name == nameToFind)
                {
                    users.Remove(item);
                    break;
                }
            }
            //if(users.Any(userName=>userName.Name == nameToFind))
            //{
            //    users.Remove();
            //}
        }

        public ICollection<User> GetAllUsers()
        {
            return users;
        }
    }
}
