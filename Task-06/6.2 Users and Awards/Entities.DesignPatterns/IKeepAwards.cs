using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DesignPatterns
{
    public interface IKeepAwards
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
    }
}
