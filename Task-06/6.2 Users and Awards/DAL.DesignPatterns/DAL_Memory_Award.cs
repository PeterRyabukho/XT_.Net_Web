using System;
using System.Collections.Generic;
using System.Text;
using Entities.DesignPatterns;
using System.Linq;

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

        public bool AddAwardToUser(Guid awardID, Guid userID)
        {
            awardsOfUsers.Add(new AwardsOfUsers(userID, awardID));
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
                this.dictionaryOfAwards.Add(award.ID, award);
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

        public IEnumerable<AwardsOfUsers> GetAllUserAwards()
        {
            foreach (var award in awardsOfUsers)
            {
                yield return award;
            }
        }

        public void RemoveAward(string nameToFind)
        {
            foreach (var whantToRemoveThisUser in dictionaryOfAwards.Values)
            {
                if (whantToRemoveThisUser.Name == nameToFind)
                {
                    dictionaryOfAwards.Remove(whantToRemoveThisUser.ID);
                    break;
                }
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
    }
}
