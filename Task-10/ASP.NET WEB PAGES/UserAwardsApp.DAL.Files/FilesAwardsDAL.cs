using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using UserAwardsApp.DAL.Abstract;
using UserAwardsApp.Entities;

namespace UserAwardsApp.DAL.Files
{
    public class FilesAwardsDAL : IAwardsDAL
    {
        private static Dictionary<Guid, Award> dictionaryOfAwards;
        private static List<AwardsOfUsers> awardsOfUsers;

        static FilesAwardsDAL()
        {
            dictionaryOfAwards = new Dictionary<Guid, Award>();
            awardsOfUsers = new List<AwardsOfUsers>();
            DeSerializerJsonAwards();
            DeSerializerJsonAwardsOfUsers();
        }

        public bool SerializerJsonAwardsOfUsers()
        {
            if (!string.IsNullOrEmpty(MyDirectory.AwardsOfUsersFile) && !string.IsNullOrWhiteSpace(MyDirectory.AwardsOfUsersFile))
            {
                var allAwardsOfUsers = from awardUser in awardsOfUsers
                                select new
                                {
                                    awardUser.UserID,
                                    awardUser.AwardID,
                                };

                var awardToJson = new { Awards = allAwardsOfUsers };

                string awardJson = JsonConvert.SerializeObject(awardToJson, Formatting.Indented);

                File.WriteAllText(MyDirectory.AwardsOfUsersFile, awardJson);

                return true;
            }
            return false;
        }

        public static bool DeSerializerJsonAwardsOfUsers()
        {
            if (!string.IsNullOrEmpty(MyDirectory.AwardsOfUsersFile) && File.Exists(MyDirectory.AwardsOfUsersFile))
            {
                string data = File.ReadAllText(MyDirectory.AwardsOfUsersFile);

                var awardsUsersList = new { AwardsUsers = new List<AwardsOfUsers>() };

                awardsUsersList = JsonConvert.DeserializeAnonymousType(data, awardsUsersList);

                if (awardsUsersList.AwardsUsers == null)
                {
                    return false;
                }

                foreach (AwardsOfUsers awardOfUsers in awardsUsersList.AwardsUsers)
                {

                    awardsOfUsers.Add(awardOfUsers);
                }
                return true;
            }
            return false;
        }

        public bool SerializerJsonAwards()
        {
            if (!string.IsNullOrEmpty(MyDirectory.AwardsFile) && !string.IsNullOrWhiteSpace(MyDirectory.AwardsFile))
            {
                var allAwards = from award in dictionaryOfAwards.Values
                                select new
                                {
                                    award.ID,
                                    award.Name,
                                    award.Image,
                                };

                var awardToJson = new { Awards = allAwards };

                string awardJson = JsonConvert.SerializeObject(awardToJson, Formatting.Indented);

                File.WriteAllText(MyDirectory.AwardsFile, awardJson);

                return true;
            }
            return false;
        }

        public static bool DeSerializerJsonAwards()
        {
            if (!string.IsNullOrEmpty(MyDirectory.AwardsFile) && File.Exists(MyDirectory.AwardsFile))
            {
                string data = File.ReadAllText(MyDirectory.AwardsFile);

                var awardsList = new { Awards = new List<Award>() };

                awardsList = JsonConvert.DeserializeAnonymousType(data, awardsList);

                if (awardsList.Awards == null)
                {
                    return false;
                }

                foreach (Award award in awardsList.Awards)
                {

                    dictionaryOfAwards.Add(award.ID, award);
                }
                return true;
            }
            return false;
        }

        public bool AddAward(Award award)
        {
            if (dictionaryOfAwards.Values.Any((name) => name.Name == award.Name))
            {
                return false;
            }

            dictionaryOfAwards.Add(award.ID, award);
            SerializerJsonAwards();

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
            SerializerJsonAwardsOfUsers();

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
                SerializerJsonAwards();

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
                SerializerJsonAwardsOfUsers();
            }
            return true;
        }

        public bool EditAward(Guid ID, string Name)
        {
            if (dictionaryOfAwards.TryGetValue(ID, out Award awardToEdit))
            {
                awardToEdit.Name = Name;
                SerializerJsonAwards();

                return true;
            }
            else
                return false;
        }
    }
}
