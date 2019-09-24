using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAwardsApp.BLL.Abstract;
using UserAwardsApp.BLL.Logic;
using UserAwardsApp.DAL.Abstract;
using UserAwardsApp.DAL.DB;
using UserAwardsApp.DAL.Files;
using UserAwardsApp.DAL.Memory;

namespace UserAwardsApp.DI.Provaiders
{
    public static class MyProvaider
    {
        public static IUserDAL userDAL { get; private set; }
        public static IUserLogic userLogic { get; private set; }
        public static IAccountDAL accountDAL { get; private set; }
        public static IAwardsDAL awardsDAL { get; private set; }
        public static IAwardsLogic awardsLogic { get; private set; }
        public static IAccountLogic accountLogic { get; private set; }

        static MyProvaider()
        {
            string typeDAL = ConfigurationManager.AppSettings["typeDAL"];
            string typeBLL = ConfigurationManager.AppSettings["typeBLL"];

            switch (typeDAL)
            {
                case "Memory":
                    {
                        userDAL = new MemoryUserDAL();
                        awardsDAL = new MemoryAwardDAL();
                        accountDAL = new MemoryAccountDAL();
                    }
                    break;
                case "Files":
                    {
                        userDAL = new FilesUserDAL();
                        awardsDAL = new FilesAwardsDAL();
                        accountDAL = new FileAccountDAL();
                    }
                    break;
                case "DB":
                    {
                        userDAL = new DBUserDAL();
                        awardsDAL = new DBAwardsDAL();
                        accountDAL = new DBAccountDAL();
                    }
                    break;
            }

            switch (typeBLL)
            {
                case "Basic":
                    {
                        userLogic = new UserManager(userDAL);
                        awardsLogic = new AwardManager(awardsDAL);
                        accountLogic = new AccountManager(accountDAL);
                    }
                    break;
            }
        }
    }

}
