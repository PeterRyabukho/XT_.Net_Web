using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UserAwardsApp.BLL.Abstract;
using UserAwardsApp.DAL.Abstract;
using UserAwardsApp.Entities;

namespace UserAwardsApp.BLL.Logic
{
    public class AwardManager : IAwardsLogic
    {
        //public static IKeepAwards AwardStorage => Dependency.awardsMemoryStorage;
        IAwardsDAL awardStorage;

        public AwardManager(IAwardsDAL DAL)
        {
            if (DAL != null)
            {
                awardStorage = DAL;
            }
            else
                throw new ArgumentNullException("DAL is null!");
        }

        public bool SerializerJsonAwards()
        {
            if (awardStorage.SerializerJsonAwards())
                return true;
            else
                return false;
        }

        public bool DeSerializerJsonAwards()
        {
            if (awardStorage.DeSerializerJsonAwards())
                return true;
            else
                return false;
        }

        public bool SerializerJsonAwardsOfUsers()
        {
            if (awardStorage.SerializerJsonAwardsOfUsers())
                return true;
            else
                return false;
        }

        public bool DeSerializerJsonAwardsOfUsers()
        {
            if (awardStorage.DeSerializerJsonAwardsOfUsers())
                return true;
            else
                return false;
        }

        public Award AddAward(string name)
        {
            //if (awardStorage.AddAward(new Award(name)))
            //    return true;
            //else
            //    return false;

            var newAward = new Award(name);

            awardStorage.AddAward(newAward);
            return newAward;
        }

        public Award AddAwardWithImg(string name, byte[] image)
        {
            var newAward = new Award(name, image);

            awardStorage.AddAward(newAward);
            return newAward;
        }

        public Award GetAwardByID(Guid ID)
        {
            return awardStorage.GetAward(ID);
        }

        public Award[] GetAllAwards()
        {
            return awardStorage.GetAllAwards().ToArray();
        }

        public Award[] GetUserAwards(User user)
        {
            return awardStorage.GetUserAwards(user).ToArray();
        }

        public bool RemoveAward(Award award)
        {
            if (awardStorage.RemoveAward(award.ID))
                return true;
            else return false;
        }

        public bool DeleteUserAwards(User user)
        {
            if (awardStorage.DeleteUserAwards(user))
                return true;
            else
                return false;
        }

        public bool AddAwardToUser(Guid userID, Guid awardID)
        {
            //if (UserManager.UserStorage.GetUserByID(userID) == null)
            //{
            //    throw new ArgumentException("User with this ID does not exist!");
            //}

            //if (AwardStorage.GetAward(awardID) == null)
            //{
            //    throw new ArgumentException("Rewards with this ID does not exist!");
            //}

            if (awardStorage.AddAwardToUser(userID, awardID))
                return true;
            else
                return false;
        }

        public bool EditAward(Guid ID, string Name)
        {
            if (awardStorage.EditAward(ID, Name))
                return true;
            else
                return false;
        }
    }
}
