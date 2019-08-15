using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DesignPatterns
{
    public class AwardsOfUsers
    {
        public Guid UserID { get; set; }

        public Guid AwardID { get; set; }

        public AwardsOfUsers()
        {
        }

        public AwardsOfUsers(Guid userID, Guid awardID)
        {
            this.UserID = userID;
            this.AwardID = awardID;
        }

        public AwardsOfUsers(User user, Award award)
        {
            this.UserID = user.ID;
            this.AwardID = award.ID;
        }
    }
}
