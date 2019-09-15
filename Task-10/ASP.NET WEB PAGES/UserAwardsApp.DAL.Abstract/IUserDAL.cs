using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAwardsApp.Entities;

namespace UserAwardsApp.DAL.Abstract
{
    public interface IUserDAL
    {
        User GetUserByID(Guid ID);
        bool AddUser(User user);
        bool RemoveUser(Guid ID);
        ICollection<User> GetAllUsers();
        bool SerializerJsonUsers();
        bool DeSerializerJsonUsers();
    }
}
