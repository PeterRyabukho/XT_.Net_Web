using System;
using System.Collections.Generic;
using System.Text;
using Entities.DesignPatterns;
using System.Linq;
using System.Threading;
using Newtonsoft.Json;

namespace DAL.DesignPatterns
{
    public class DAL_Memory_Award: IKeepAwards
    {
        private Dictionary<Guid, Award> dictionaryOfAwards;
        private List<AwardsOfUsers> awardsOfUsers;

        public DAL_Memory_Award()
        {
            dictionaryOfAwards = new Dictionary<Guid, Award>();
            awardsOfUsers = new List<AwardsOfUsers>();
        }

        public bool AddAward(Award award)
        {
            //if (GetAward(award.ID) == null)
            //{
            //    return false;
            //}

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

        //public void RemoveAward(string nameToFind)
        //{
        //    foreach (var whantToRemoveThisUser in dictionaryOfAwards.Values)
        //    {
        //        if (whantToRemoveThisUser.Name == nameToFind)
        //        {
        //            dictionaryOfAwards.Remove(whantToRemoveThisUser.ID);
        //            break;
        //        }
        //    }
        //}

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

        public void DeleteUserAwards(User user)
        {
            var newAwardsOfUsers = new List<AwardsOfUsers>();
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

        public void ShowCollectionAwardsOfUsers()
        {
            throw new NotImplementedException();
        }
    }
}
