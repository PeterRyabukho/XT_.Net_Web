using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAwardsApp.Entities;

namespace UserAwardsApp.DAL.Abstract
{
    public interface IAccountDAL
    {
        Account GetAccountByID(Guid ID);
        Account AddAccount(Account account);
        ICollection<Account> GetAllAccounts();
        bool RemoveAccount(Guid ID);
        bool SerializerJsonAccounts();
        bool DeSerializerJsonAccounts();
        bool EditAccount(Guid ID, string login, string password, string role);


    }
}
