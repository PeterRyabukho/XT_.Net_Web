using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAwardsApp.DAL.Abstract;
using UserAwardsApp.Entities;

namespace UserAwardsApp.DAL.Files
{
    public class FileAccountDAL: IAccountDAL
    {
        public static Dictionary<Guid, Account> accountDictionary { get; set; }

        static FileAccountDAL()
        {
            accountDictionary = new Dictionary<Guid, Account>();

            DeSerializerJsonUsers();
        }

        public bool SerializerJsonAccount()
        {
            if (!string.IsNullOrEmpty(MyDirectory.AccountsFile) && !string.IsNullOrWhiteSpace(MyDirectory.AccountsFile))
            {
                var allAccounts = from account in accountDictionary.Values
                               select new
                               {
                                   account.ID,
                                   account.Login,
                                   account.Password,
                                   account.Role
                               };

                var accountToJson = new { Accounts = allAccounts };

                string accountJson = JsonConvert.SerializeObject(accountToJson, Formatting.Indented);

                File.WriteAllText(MyDirectory.AccountsFile, accountJson);
                return true;
            }
            return false;
        }

        public static bool DeSerializerJsonUsers()
        {
            if (!string.IsNullOrEmpty(MyDirectory.AccountsFile) && File.Exists(MyDirectory.AccountsFile))
            {
                string data = File.ReadAllText(MyDirectory.AccountsFile);

                var accountsList = new { Accounts = new List<Account>() };

                accountsList = JsonConvert.DeserializeAnonymousType(data, accountsList);

                if(accountsList.Accounts == null)
                {
                    return false;
                }

                foreach (Account account in accountsList.Accounts)
                {

                    accountDictionary.Add(account.ID, account);
                }
                return true;
            }
            return false;
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

            SerializerJsonAccount();
            return account;
        }

        public IEnumerable<Account> GetAllAccounts()
        {
            return accountDictionary.Values.ToList();
        }

        public bool RemoveAccount(Guid ID)
        {
            if (accountDictionary.ContainsKey(ID))
            {
                accountDictionary.Remove(ID);

                SerializerJsonAccount();
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

                SerializerJsonAccount();
                return true;
            }
            else
                return false;
        }
    }
}

