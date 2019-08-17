using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DesignPatterns
{
    public class AwardsOfUsers
    {
        public Guid UserID { get; set; }

        public Guid AwardID { get; set; }

        public AwardsOfUsers(Guid userID, Guid awardID)
        {
            this.UserID = userID;
            this.AwardID = awardID;
        }
    }
}
