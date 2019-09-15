using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserAwardsApp.Entities
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
