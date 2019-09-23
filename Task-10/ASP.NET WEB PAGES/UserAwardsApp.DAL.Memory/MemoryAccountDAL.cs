using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAwardsApp.DAL.Abstract;
using UserAwardsApp.Entities;

namespace UserAwardsApp.DAL.Memory
{
    public class MemoryAccountDAL : IAccountDAL
    {
        public Dictionary<Guid, Account> accountDictionary { get; set; }

        public MemoryAccountDAL()
        {
            accountDictionary = new Dictionary<Guid, Account>();
        }

        public Account GetAccountByID(Guid ID)
        {
            return accountDictionary.ContainsKey(ID) ? accountDictionary[ID] : null;
        }

        public Account AddAccount(Account account)
        {
            //if (usersDictionary.Values.Any(userName => userName.Name == user.Name) && GetUserByID(user.ID) != null)
            //{
            //return false;
            //}

            accountDictionary.Add(account.ID, account);
            return account;
        }

        public ICollection<Account> GetAllAccounts()
        {
            return accountDictionary.Values.ToList();
        }

        public bool RemoveAccount(Guid ID)
        {
            if (accountDictionary.ContainsKey(ID))
            {
                accountDictionary.Remove(ID);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SerializerJsonAccounts()
        {
            throw new NotImplementedException();
        }

        public bool DeSerializerJsonAccounts()
        {
            throw new NotImplementedException();
        }

        public bool EditAccount(Guid ID, string login, string password, string role)
        {
            if (accountDictionary.ContainsKey(ID))
            {
                var myCol = accountDictionary.TryGetValue(ID, out Account accountToEdit);

                accountToEdit.Login = login;
                accountToEdit.Password = password;
                accountToEdit.Role = role;
                return true;
            }
            else
                return false;
        }
    }

}

