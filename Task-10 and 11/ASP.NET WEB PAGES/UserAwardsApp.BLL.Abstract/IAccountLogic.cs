using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAwardsApp.Entities;

namespace UserAwardsApp.BLL.Abstract
{
    public interface IAccountLogic
    {
        Account CreateAccount(string login, string password, string role);
        Account GetAccountByID(Guid ID);
        void AddAccount(Account account);
        bool RemoveAccount(Account account);
        Account[] GetAllAccounts();
        bool EditAccount(Guid ID, string login, string password, string role);
    }
}
