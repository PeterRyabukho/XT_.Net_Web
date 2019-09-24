using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAwardsApp.Entities
{
    public static class MyDirectory
    {
        public static string CreateDirectory { get; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-06\";
        public static string UsersFile => $"{CreateDirectory}Users.txt";
        public static string AwardsFile => $"{CreateDirectory}Awards.txt";
        public static string AwardsOfUsersFile => $"{CreateDirectory}Awards of Users.txt";
        public static string ConfigFile => $"{CreateDirectory}Config.txt";
        public static string AccountsFile => $"{CreateDirectory}Account.txt";

        static MyDirectory()
        {
            if (!Directory.Exists(CreateDirectory))
            {
                Directory.CreateDirectory(CreateDirectory);
            }
            if (!File.Exists(UsersFile))
            {
                List<User> users = new List<User>();
                User firsUser = new User("Iron Man", DateTime.Parse("1990-04-04T00:00:00"));
                users.Add(firsUser);

                var allUsers = from user in users
                                  select new
                                  {
                                      user.ID,
                                      user.Name,
                                      user.DateOfBirth,
                                      user.Age,
                                      user.Image
                                  };

                var userToJson = new { Users = allUsers };

                string userJson = JsonConvert.SerializeObject(userToJson, Formatting.Indented);

                File.WriteAllText(MyDirectory.UsersFile, userJson);
            }
            if (!File.Exists(AwardsFile))
            {
                List<Award> awards = new List<Award>();
                Award firsAward = new Award("Super Hero");
                awards.Add(firsAward);

                var allAwards = from award in awards
                               select new
                               {
                                   award.ID,
                                   award.Name,
                                   award.Image,
                               };

                var awardToJson = new { Awards = allAwards };

                string awardJson = JsonConvert.SerializeObject(awardToJson, Formatting.Indented);

                File.WriteAllText(MyDirectory.AwardsFile, awardJson);
            }
            if (!File.Exists(AwardsOfUsersFile))
            {
                List<AwardsOfUsers> awardsOfUsers = new List<AwardsOfUsers>();
                AwardsOfUsers firstAwardOfUser = new AwardsOfUsers(Guid.Parse("a725ee6b-a48f-44f2-b80c-45ec383f6976"), Guid.Parse("55eca31b-8ae3-462a-8b0e-cc166a691c1d"));
                awardsOfUsers.Add(firstAwardOfUser);

                var allAwardsOfUsers = from awardUser in awardsOfUsers
                                       select new
                                       {
                                           awardUser.UserID,
                                           awardUser.AwardID,
                                       };

                var awardToJson = new { Awards = allAwardsOfUsers };

                string awardJson = JsonConvert.SerializeObject(awardToJson, Formatting.Indented);

                File.WriteAllText(MyDirectory.AwardsOfUsersFile, awardJson);
            }
            if (!File.Exists(ConfigFile))
            {
                using (StreamWriter writer = new StreamWriter(ConfigFile, true))
                {
                    writer.WriteLine("");
                }
            }
            if (!File.Exists(AccountsFile))
            {
                //File.Create(AccountsFile);
                //using (StreamWriter writer = new StreamWriter(AccountsFile, true))
                //{
                List<Account> accounts = new List<Account>();
                    Account firsAccount = new Account("Admin", "ACcanO9keaJuooas/fFpuyJ44W6O1R87frSPUVlu846044x7yxQHH+zdl/8E3cTfYA==", "Admin");
                accounts.Add(firsAccount);

                    var allAccounts = from account in accounts
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
                    //writer.WriteLine(" ");
                //}
            }
        }
        public static void Check()
        {

        }
        public static bool CheckOrCreateDirectoryAndFiles()
        {
            if (!Directory.Exists(CreateDirectory))
            {
                return true;
            }
            if (!File.Exists(UsersFile))
            {
                return true;
            }
            if (!File.Exists(AwardsFile))
            {
                return true;
            }
            if (!File.Exists(AwardsOfUsersFile))
            {
                return true;
            }
            if (!File.Exists(ConfigFile))
            {
                return true;
            }
            if (!File.Exists(AccountsFile))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
