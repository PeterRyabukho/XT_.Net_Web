using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAwardsApp.BLL.Abstract;
using UserAwardsApp.DAL.Abstract;
using UserAwardsApp.Entities;

namespace UserAwardsApp.BLL.Logic
{
    public class UserManager : IUserLogic
    {
        IUserDAL userStorage;

        public UserManager(IUserDAL DAL)
        {
            if (DAL != null)
            {
                userStorage = DAL;
            }
            else
                throw new ArgumentNullException("DAL is null!");
        }

        public bool SerializerJsonUsers()
        {
            if (userStorage.SerializerJsonUsers())
                return true;
            else
                return false;
        }

        public bool DeSerializerJsonUsers()
        {
            if (userStorage.DeSerializerJsonUsers())
                return true;
            else
                return false;
        }
        public void CreateUser(string name, DateTime dateOfBith)
        {
            userStorage.AddUser(new User(name, dateOfBith) { DateOfBirth = dateOfBith, Name = name });
        }

        public User GetUserByID(Guid ID)
        {
            return userStorage.GetUserByID(ID);
        }

        public void AddUser(User user)
        {
            userStorage.AddUser(user);
        }

        public bool RemoveUser(User user)
        {
            if (userStorage.RemoveUser(user.ID))
                return true;
            else
                return false;
        }

        public User[] GetAllUsers()
        {
            return userStorage.GetAllUsers().ToArray();
        }

    }

}
