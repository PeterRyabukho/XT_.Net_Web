﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserAwardsApp.DAL.Abstract;
using UserAwardsApp.Entities;

namespace UserAwardsApp.DAL.Memory
{
    public class MemoryAwardDAL : IAwardsDAL
    {
        private Dictionary<Guid, Award> dictionaryOfAwards;
        private List<AwardsOfUsers> awardsOfUsers;

        public MemoryAwardDAL()
        {
            dictionaryOfAwards = new Dictionary<Guid, Award>();
            awardsOfUsers = new List<AwardsOfUsers>();
        }

        public bool AddAward(Award award)
        {
            if (dictionaryOfAwards.Values.Any((name) => name.Name == award.Name))
            {
                return false;
            }

            dictionaryOfAwards.Add(award.ID, award);
            return true;
        }

        public Award GetAward(Guid ID)
        {
            return dictionaryOfAwards.ContainsKey(ID) ? dictionaryOfAwards[ID] : null;
        }

        public IEnumerable<Award> GetAllAwards()
        {
            return dictionaryOfAwards.Values.ToList();
        }

        public bool AddAwardToUser(Guid userID, Guid awardID)
        {
            AwardsOfUsers awardOfUser = new AwardsOfUsers(userID, awardID);
            if (awardsOfUsers.Any((user) => user.AwardID == awardID && user.UserID == userID))
                return false;
            awardsOfUsers.Add(awardOfUser);
            Thread.Sleep(50);
            return true;
        }

        public IEnumerable<Award> GetUserAwards(User user)
        {
            foreach (var oneUser in awardsOfUsers)
            {
                if (oneUser.UserID == user.ID)
                {
                    yield return GetAward(oneUser.AwardID);
                }
            }
        }

        public void SetAllAwards(IEnumerable<Award> awards)
        {
            dictionaryOfAwards.Clear();
            foreach (var award in awards)
            {
                dictionaryOfAwards.Add(award.ID, award);
            }
        }

        public void SetAllUserAwards(IEnumerable<AwardsOfUsers> awardsOfUsers)
        {
            this.awardsOfUsers.Clear();
            foreach (var awardsOf in awardsOfUsers)
            {
                this.awardsOfUsers.Add(awardsOf);
            }
        }

        public IEnumerable<AwardsOfUsers> GetAllUsersAwards()
        {
            foreach (var award in awardsOfUsers)
            {
                yield return award;
            }
        }

        public bool RemoveAward(Guid ID)
        {
            if (dictionaryOfAwards.ContainsKey(ID))
            {
                dictionaryOfAwards.Remove(ID);
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool DeleteUserAwards(User user)
        {
            var newAwardsOfUsers = new List<AwardsOfUsers>();
            if (awardsOfUsers == null)
                return false;
            foreach (var newUserOne in awardsOfUsers)
            {
                if (newUserOne.UserID != user.ID)
                {
                    newAwardsOfUsers.Add(newUserOne);
                }
            }


            awardsOfUsers.Clear();
            foreach (var userOne in newAwardsOfUsers)
            {
                awardsOfUsers.Add(userOne);
            }
            return true;
        }

        public bool SerializerJsonAwards()
        {
            throw new NotImplementedException();
        }

        public bool SerializerJsonAwardsOfUsers()
        {
            throw new NotImplementedException();
        }

        public bool DeSerializerJsonAwardsOfUsers()
        {
            throw new NotImplementedException();
        }

        public bool DeSerializerJsonAwards()
        {
            throw new NotImplementedException();
        }
    }

}
