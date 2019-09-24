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
    public class AccountManager: IAccountLogic
    {
        IAccountDAL accountStorage;

        public AccountManager(IAccountDAL DAL)
        {
            if (DAL != null)
            {
                accountStorage = DAL;
            }
            else
                throw new ArgumentNullException("DAL is null!");
        }

        public Account CreateAccount(string login, string password, string role)
        {
            var newAccount = new Account(login, password, role) { Login = login, Password = password, Role = role };
            accountStorage.AddAccount(newAccount);
            return newAccount;
        }

        public Account GetAccountByID(Guid ID)
        {
            return accountStorage.GetAccountByID(ID);
        }

        public void AddAccount(Account account)
        {
            accountStorage.AddAccount(account);
        }

        public bool RemoveAccount(Account account)
        {
            if (accountStorage.RemoveAccount(account.ID))
                return true;
            else
                return false;
        }

        public Account[] GetAllAccounts()
        {
            return accountStorage.GetAllAccounts().ToArray();
        }

        public bool EditAccount(Guid ID, string login, string password, string role)
        {
            if (accountStorage.EditAccount(ID, login, password, role))
                return true;
            else
                return false;
        }

    }
}
