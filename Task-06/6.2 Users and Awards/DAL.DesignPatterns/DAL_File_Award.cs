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
    public class DAL_File_Award : IKeepAwards
    {
        private static string createDirectory { get; } = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments) + @"\Peter Task-06\";
        private static string pathToFile { get; } = $"{createDirectory}Awards.txt";

        private Dictionary<Guid, Award> dictionaryOfAwards;
        private List<AwardsOfUsers> awardsOfUsers;

        public DAL_File_Award()
        {
            if (!Directory.Exists(createDirectory))
            {
                Directory.CreateDirectory(createDirectory);
            }
            if (!File.Exists(pathToFile))
            {
                File.Create(pathToFile);
            }
            dictionaryOfAwards = new Dictionary<Guid, Award>();
            awardsOfUsers = new List<AwardsOfUsers>();
        }

        public bool SerializerJsonAwards()
        {
            //if (dictionaryOfAwards.Values.Count != 0)
            //{
            //    JsonSerializer serializer = new JsonSerializer();
            //    serializer.Converters.Add(new JavaScriptDateTimeConverter());
            //    serializer.NullValueHandling = NullValueHandling.Ignore;

            //    using (StreamWriter sw = new StreamWriter(pathToFile))
            //    using (JsonWriter writer = new JsonTextWriter(sw))
            //    {
            //        foreach (var award in dictionaryOfAwards.Values)
            //        {
            //            serializer.Serialize(writer, award);
            //        }
            //    }
            //    return true;
            //}
            //return false;

            //var awards = dictionaryOfAwards.Values.ToArray();
            //if (awards.Length == 0)
            //    return false;
            //for (int i = 0; i < awards.Length; i++)
            //{
            //    string output = JsonConvert.SerializeObject(awards[i]);
            //    File.WriteAllText(pathToFile, output);
            //}
            //return true;

            //COOLE
            AllAwards awards = new AllAwards();
            foreach (var item in dictionaryOfAwards.Values)
            {
                awards.Awards.Add(item);
            }
            if (awards.Awards.Count == 0)
                return false;
            else
            {
                //award.Awards = GetAllAwards().ToList();
                string show = JsonConvert.SerializeObject(awards.Awards, Formatting.Indented);
                Thread.Sleep(50);
                File.AppendAllText(pathToFile, show);
                return true;
            }

            //var awards = GetAllAwards().ToArray();
            //if (awards.Length == 0)
            //    return false;
            //else
            //{
            //    for (int i = 0; i < awards.Length; i++)
            //    {
            //        string output = JsonConvert.SerializeObject(awards[i], Formatting.Indented);
            //        File.AppendAllText(pathToFile, output);
            //    }
            //    return true;
            //}

            //foreach (var award in GetAllAwards())
            //{
            //    string output = JsonConvert.SerializeObject(award, Formatting.Indented);
            //    File.AppendAllText(pathToFile, output);
            //}
            //return true;
        }

        public void DeSerializerJsonAwards()
        {
            
            List<Award> awards = JsonConvert.DeserializeObject<List<Award>>(File.ReadAllText(pathToFile));

            foreach (var award in awards)
            {
                dictionaryOfAwards.Add(award.ID, award);
            }
            //string[] fileLines = File.ReadAllLines(pathToFile);
            //foreach (var line in fileLines)
            //{
            //    //Award deserializedAward = JsonConvert.DeserializeObject<Award>();
            //    //dictionaryOfAwards.Add(deserializedAward.ID, deserializedAward);
            //    //var output = line.Split('{', '}');
            //    //foreach (var item in output)
            //    //{
                   
            //    //}
            //}
            
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
        //public Award GetAward(Guid ID)
        //{
        //    throw new NotImplementedException();
        //}

        //public bool AddAward(Award award)
        //{
        //    if (GetAward(award.ID) != null)
        //    {
        //        return false;
        //    }

        //    try
        //    {
        //        File.AppendAllLines(pathToFile, new string[] { award.ID.ToString(), "▄", award.Name });
        //        return true;
        //    }
        //    catch
        //    {
        //        return false;
        //    }
        //}
        //public IEnumerable<Award> GetAllAwards()
        //{
        //    throw new NotImplementedException();
        //    //string[] lines = File.ReadAllLines(pathToFile);
        //    //foreach (string line in lines)
        //    //{
        //    //    var award CreateAwardFromLine(line);
        //    //    if (award != null)
        //    //    {
        //    //        yield return award;
        //    //    }
        //    //}
        //}

        //public bool AddAwardToUser(Guid userID, Guid awardID)
        //{
        //    throw new NotImplementedException();
        //}

        //public void DeleteUserAwards(User user)
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<AwardsOfUsers> GetAllUsersAwards()
        //{
        //    throw new NotImplementedException();
        //}

        //public IEnumerable<Award> GetUserAwards(User user)
        //{
        //    throw new NotImplementedException();
        //}

        //public void RemoveAward(string nameToFind)
        //{
        //    throw new NotImplementedException();
        //}

        //public void SetAllAwards(IEnumerable<Award> awards)
        //{
        //    throw new NotImplementedException();
        //}

        //public void SetAllUserAwards(IEnumerable<AwardsOfUsers> awardsOfUsers)
        //{
        //    throw new NotImplementedException();
        //}
