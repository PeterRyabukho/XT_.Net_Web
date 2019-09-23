using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserAwardsApp.BLL.Abstract;
using UserAwardsApp.DI.Provaiders;
using UserAwardsApp.Entities;

namespace UserAwardsApp.PL.UIWebPages.HelpersBLL
{
    public static class Provaiders
    {
        public static IUserLogic userLogic = MyProvaider.userLogic;
        public static IAwardsLogic awardsLogic = MyProvaider.awardsLogic;
        public static IAccountLogic accountLogic = MyProvaider.accountLogic;

        public static Dictionary<int, Guid> UserIDs = new Dictionary<int, Guid>();

        public static Dictionary<int, Guid> AwardIDs = new Dictionary<int, Guid>();

    }
}