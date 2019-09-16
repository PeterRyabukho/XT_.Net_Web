using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using UserAwardsApp.BLL.Abstract;
using UserAwardsApp.DI.Provaiders;

namespace UserAwardsApp.PL.UIWebPages.HelpersBLL
{
    public static class Provaiders
    {
        public static IUserLogic userLogic = MyProvaider.userLogic;
        public static IAwardsLogic awardsLogic = MyProvaider.awardsLogic;
    }
}