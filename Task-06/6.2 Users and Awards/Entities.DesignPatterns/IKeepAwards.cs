﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Entities.DesignPatterns
{
    public interface IKeepAwards
    {
        bool AddAward(Award award);
        Award GetAward(Guid ID);
        IEnumerable<Award> GetAllAwards();
        bool AddAwardToUser(Guid awardID, Guid userID);
        IEnumerable<Award> GetUserAwards(User user);
        void SetAllAwards(IEnumerable<Award> awards);
        void SetAllUserAwards(IEnumerable<AwardsOfUsers> awardsOfUsers);
        IEnumerable<AwardsOfUsers> GetAllUserAwards();
        void RemoveAward(string nameToFind);
        void DeleteUserAwards(User user);

    }
}
