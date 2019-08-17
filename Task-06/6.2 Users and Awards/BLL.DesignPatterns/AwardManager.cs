using System;
using System.Collections.Generic;
using System.Text;
using Entities.DesignPatterns;
using Dependencys.DesignPatterns;
using System.Linq;

namespace BLL.DesignPatterns
{
    public static class AwardManager
    {
        public static IKeepAwards AwardStorage => Dependency.awardsStorage;

        public static bool SerializerJsonAwards()
        {
            if (AwardStorage.SerializerJsonAwards())
                return true;
            else
                return false;
            //throw new NullReferenceException("Empty list");
        }

        public static bool DeSerializerJsonAwards()
        {
            if(AwardStorage.DeSerializerJsonAwards())
                return true;
            else
                return false;
        }

        public static bool SerializerJsonAwardsOfUsers()
        {
            if (AwardStorage.SerializerJsonAwardsOfUsers())
                return true;
            else
                return false;
        }

        public static bool DeSerializerJsonAwardsOfUsers()
        {
            if (AwardStorage.DeSerializerJsonAwardsOfUsers())
                return true;
            else
                return false;
        }
        public static bool AddAward(string name)
        {
            //AwardStorage.AddAward(new Award(name));
            //var award = new Award(name);
            //var arr = GetAllAwards();
            //for (int i = 0; i < arr.Length; i++)
            //{
            //    if (arr[i].Name == name)
            //        return false;
            //}
            if (AwardStorage.AddAward(new Award(name)))
                return true;
            else
                return false;
        }

        public static bool AddAward(Award award)
        {
            if (AwardStorage.AddAward(award))
                return true;
            else
                return false;
        }

        public static Award GetAwardByID(Guid ID)
        {
            return AwardStorage.GetAward(ID);
        }

        public static Award[] GetAllAwards()
        {
            return AwardStorage.GetAllAwards().ToArray();
        }

        public static Award[] GetUserAwards(User user)
        {
            return AwardStorage.GetUserAwards(user).ToArray();
        }

        public static bool RemoveAward(Award award)
        {
            if (AwardStorage.RemoveAward(award.ID))
                return true;
            else return false;
        }

        public static void ShowCollectionAwardsOfUsers()
        {
            AwardStorage.ShowCollectionAwardsOfUsers();
        }

        public static bool AddAwardToUser(Guid userID, Guid awardID)
        {
            //if (UserManager.UserStorage.GetUserByID(userID) == null)
            //{
            //    throw new ArgumentException("User with this ID does not exist!");
            //}

            //if (AwardStorage.GetAward(awardID) == null)
            //{
            //    throw new ArgumentException("Rewards with this ID does not exist!");
            //}

            if (AwardStorage.AddAwardToUser(userID, awardID))
            {
                //Thread cashThread = new Thread(this.UsersAndAwardsCashing);
                //cashThread.Start();
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
