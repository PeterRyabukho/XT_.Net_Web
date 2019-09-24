using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAwardsApp.Entities;

namespace UserAwardsApp.BLL.Abstract
{
    public interface IUserLogic
    {
        //void CreateUser(string name, DateTime dateOfBith);
        User GetUserByID(Guid ID);
        void AddUser(User user);
        User CreateUser(string name, DateTime dateOfBith);
        User CreateUserWithImg(string name, DateTime dateOfBith, byte[] image);
        bool RemoveUser(User user);
        User[] GetAllUsers();
        bool SerializerJsonUsers();
        bool DeSerializerJsonUsers();
        bool EditUser(Guid ID, string Name, DateTime dOB);
    }
}
