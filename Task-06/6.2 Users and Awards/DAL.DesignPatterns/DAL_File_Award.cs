using System;
using System.Collections.Generic;
using System.Text;
using Entities.DesignPatterns;
using System.Linq;
using System.Threading;
using System.IO;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace DAL.DesignPatterns
{
    public class DAL_File_Award :IKeepAwards
    {
        private Dictionary<Guid, Award> dictionaryOfAwards;
        private List<AwardsOfUsers> awardsOfUsers;

        public DAL_File_Award()
        {
            dictionaryOfAwards = new Dictionary<Guid, Award>();
            awardsOfUsers = new List<AwardsOfUsers>();
        }

        public bool SerializerJsonAwardsOfUsers()
        {
            All_Awards_Of_Users awardsOfAllUsers = new All_Awards_Of_Users();
            foreach (var item in awardsOfUsers)
            {
                awardsOfAllUsers.AwardsOfUsers.Add(item);
            }
            if (awardsOfAllUsers.AwardsOfUsers.Count == 0)
                return false;
            else
            {
                string awardsOfUsersSerialize = JsonConvert.SerializeObject(awardsOfAllUsers.AwardsOfUsers, Formatting.Indented);
                Thread.Sleep(50);
                File.WriteAllText(MyDirectory.AwardsOfUsersFile, awardsOfUsersSerialize, Encoding.Default);
                return true;
            }
        }

        public bool DeSerializerJsonAwardsOfUsers()
        {
            List<AwardsOfUsers> deserialize = JsonConvert.DeserializeObject<List<AwardsOfUsers>>(File.ReadAllText(MyDirectory.AwardsOfUsersFile));
            if (deserialize == null)
                return false;
            foreach (var awards in deserialize)
            {
                awardsOfUsers.Add(awards);
            }
            return true;
        }

        public bool SerializerJsonAwards()
        {
            AllAwards awards = new AllAwards();
            foreach (var item in dictionaryOfAwards.Values)
            {
                awards.Awards.Add(item);
            }
            if (awards.Awards.Count == 0)
                return false;
            else
            {
                string show = JsonConvert.SerializeObject(awards.Awards, Formatting.Indented);
                Thread.Sleep(50);
                File.WriteAllText(MyDirectory.AwardsFile, show, Encoding.Default);
                return true;
            }
        }

        public bool DeSerializerJsonAwards()
        {
            
            List<Award> awards = JsonConvert.DeserializeObject<List<Award>>(File.ReadAllText(MyDirectory.AwardsFile));
            if (awards == null)
                return false;
            foreach (var award in awards)
            {
                dictionaryOfAwards.Add(award.ID, award);
            }
            return true;
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
    }

}
