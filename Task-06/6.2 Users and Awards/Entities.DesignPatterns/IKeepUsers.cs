using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DesignPatterns
{
    public interface IKeepUsers
    {
        User GetUserByID(Guid ID);
        bool AddUser(User user);

        void RemoveUser(string nameToFind);

        //ICollection<string> GetAllUsers();
        ICollection<User> GetAllUsers();
        bool SetAllUsers(IEnumerable<User> users);
    }
}
