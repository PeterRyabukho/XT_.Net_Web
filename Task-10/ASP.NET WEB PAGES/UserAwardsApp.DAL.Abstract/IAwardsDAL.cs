using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAwardsApp.Entities;

namespace UserAwardsApp.DAL.Abstract
{
    public interface IAwardsDAL
    {
        bool AddAward(Award award);
        Award GetAward(Guid ID);
        IEnumerable<Award> GetAllAwards();
        bool AddAwardToUser(Guid userID, Guid awardID);
        IEnumerable<Award> GetUserAwards(User user);
        bool RemoveAward(Guid ID);
        bool DeleteUserAwards(User user);
        bool SerializerJsonAwards();
        bool DeSerializerJsonAwards();
        bool SerializerJsonAwardsOfUsers();
        bool DeSerializerJsonAwardsOfUsers();
        bool EditAward(Guid ID, string Name);
    }
}
