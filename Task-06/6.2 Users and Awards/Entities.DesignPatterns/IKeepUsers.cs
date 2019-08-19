using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DesignPatterns
{
    public interface IKeepUsers
    {
        User GetUserByID(Guid ID);
        bool AddUser(User user);
        bool RemoveUser(Guid ID);
        ICollection<User> GetAllUsers();
        bool SerializerJsonUsers();
        bool DeSerializerJsonUsers();
    }
}
