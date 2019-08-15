using System;
using System.Collections.Generic;
using System.Text;
using Entities.DesignPatterns;
using Dependencys.DesignPatterns;
using System.Linq;

namespace BLL.DesignPatterns
{
    public static class UserManager
    {
        public static IKeepUsers UserStorage => Dependency.usersStorage;

        public static void CreateUser(string name, DateTime dateOfBith)
        {
            UserStorage.AddUser(new User (name, dateOfBith) { DateOfBirth = dateOfBith, Name = name });
        }

        public static User GetUserByID(Guid ID)
        {
            return UserStorage.GetUserByID(ID);
        }
        public static void AddUser(User user)
        {
            UserStorage.AddUser(user);
        }

        public static void RemoveUser(string nameToFind)
        {
            UserStorage.RemoveUser(nameToFind);
        }

        public static User[] GetAllUsers()
        {
            return UserStorage.GetAllUsers().ToArray();
        }

        //public static ICollection<string> GetAllUsers()
        //{
        //    return UserStorage.GetAllUsers();
        //}
    }
}
