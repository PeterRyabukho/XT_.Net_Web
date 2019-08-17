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
        //ICollection<string> GetAllUsers();
        ICollection<User> GetAllUsers();
        bool SetAllUsers(IEnumerable<User> users);
        bool SerializerJsonUsers();
        bool DeSerializerJsonUsers();
    }
}
