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

        //public Dictionary<int, Guid> UserIDs = new Dictionary<int, Guid>();

        //public bool ShowUsersAndAddNumbers()
        //{
        //    UserIDs.Clear();
        //    List<User> allUsers = userStorage.GetAllUsers().ToList();
        //    if (allUsers.Count == 0)
        //        return false;
        //    int numberOfUser = 1;
        //    foreach (var item in allUsers)
        //    {
        //        UserIDs.Add(numberOfUser, item.ID);
        //        numberOfUser++;
        //    }
        //    return true;
        //}

        public bool SerializerJsonUsers()
        {
            if (userStorage.SerializerJsonUsers())
                return true;
            else
                return false;
        }

        //public bool DeSerializerJsonUsers()
        //{
        //    if (userStorage.DeSerializerJsonUsers())
        //        return true;
        //    else
        //        return false;
        //}

        public User CreateUser(string name, DateTime dateOfBith)
        {
            var newUser = new User(name, dateOfBith) { DateOfBirth = dateOfBith, Name = name };
            userStorage.AddUser(newUser);
            return newUser;
        }

        public User CreateUserWithImg(string name, DateTime dateOfBith, byte[] image)
        {
            var newUser = new User(name, dateOfBith, image) { DateOfBirth = dateOfBith, Name = name, Image = image };
            userStorage.AddUser(newUser);
            return newUser;
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

        public bool EditUser(Guid ID, string Name, DateTime dOB)
        {
            if (userStorage.EditUser(ID, Name, dOB))
                return true;
            else
                return false;
        }
    }

}
