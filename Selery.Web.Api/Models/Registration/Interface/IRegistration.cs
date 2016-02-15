using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selery.Model.Entity.Registration;
using Selery.BO.Entity.Registration;

namespace Selery.Web.Api.Models.Registration.Interface
{
    public interface IRegistration
    {
         User CreateUser(User user);
         int FindUserByEmail(string email);
         int FindUserByFacebookID(long facebookID);
         User SelectUserByEmail(string email);
         User SelectUserByID(int userID);
         User SelectUserByFacebookID(long facebookID);
         User UpdateUserRegistration(User user);
         User UpdateUserProfile(User user);
         User LoginByEmail(string email, byte[] password);
         IEnumerable<Activity> SelectActivity();
         IEnumerable<Goal> SelectGoal();
         int UserWeightInsert(int userID, decimal weight);
         Boolean IsProfileComplete(int userID);
    }
}
