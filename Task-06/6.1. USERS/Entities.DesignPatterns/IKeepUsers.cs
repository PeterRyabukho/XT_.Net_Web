using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DesignPatterns
{
    public interface IKeepUsers
    {
        bool AddUser(User user);

        void RemoveUser(string nameToFind);

        ICollection<string> GetAllUsers();
    }
}
