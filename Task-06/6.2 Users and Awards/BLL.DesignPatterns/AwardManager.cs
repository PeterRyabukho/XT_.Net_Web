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

        public static void DeSerializerJsonAwards()
        {
            AwardStorage.DeSerializerJsonAwards();
        }

        public static void CreateAward(string name)
        {
            AwardStorage.AddAward(new Award(name));
            //var award = new Award(name);

            //if (AwardStorage.AddAward(award))
            //    return true;
            //else
            //    return false;
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

        public static void RemoveAward(string nameToFind)
        {
            AwardStorage.RemoveAward(nameToFind);
        }


        public static bool AddAwardToUser(Guid userID, Guid awardID)
        {
            if (UserManager.UserStorage.GetUserByID(userID) == null)
            {
                throw new ArgumentException("Пользователя с данным ID не существует");
            }

            if (AwardStorage.GetAward(awardID) == null)
            {
                throw new ArgumentException("Награды с данным ID не существует");
            }

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
