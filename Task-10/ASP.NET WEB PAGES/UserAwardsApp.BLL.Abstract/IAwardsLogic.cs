using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAwardsApp.Entities;

namespace UserAwardsApp.BLL.Abstract
{
    public interface IAwardsLogic
    {
        //bool AddAward(string name);
        Award AddAward(string name);
        Award GetAwardByID(Guid ID);
        Award[] GetAllAwards();
        bool AddAwardToUser(Guid userID, Guid awardID);
        Award[] GetUserAwards(User user);
        bool RemoveAward(Award award);
        bool DeleteUserAwards(User user);
        bool SerializerJsonAwards();
        bool DeSerializerJsonAwards();
        bool SerializerJsonAwardsOfUsers();
        bool DeSerializerJsonAwardsOfUsers();
        bool EditAward(Guid ID, string Name);
    }
}
