using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selery.Web.Api.Models.Registration.Interface;
using Selery.Model;
using Selery.Model.Entity.Registration;
using Selery.Model.Entity.Workout;
using Selery.BO.Entity.Registration;
using Selery.BO.Entity.Workout;
using Selery.Library.Common;
using Selery.Web.Api.Models.Workout.Repository;
using Selery.Web.Api.Models.Workout.Interface;
using Selery.Web.Api.Models.Nutrition.Interface;
using Selery.Web.Api.Models.Nutrition.Repository;

namespace Selery.Web.Api.Models.Registration.Repository
{
    public class RegistrationRepository :IRegistration
    {
        private  IWorkout _workoutRepository;
        private INutrition _nutritionRepository;
        public RegistrationRepository()
        {
            _workoutRepository = new WorkoutRepository();
            _nutritionRepository = new NutritionRepository();
        }

        /// <summary>
        /// Crea un nuevo usuario
        /// </summary>
        /// <param name="firstName"></param>
        /// <param name="lastName"></param>
        /// <param name="email"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        public User CreateUser(User user)
        {   

            using (var context = new RegistrationEntities())
            {
                int  userID = (int)context.spInsertUser(user.FirstName, user.LastName, user.Email, (long?)user.FacebookID.ToNull(), user.Password).FirstOrDefault().UserID;
                return SelectUserByID(userID);
            }

        }
        public int FindUserByEmail(string email)
        {
            int userID = 0;

            using (var context = new RegistrationEntities())
            {

                userID = context.spFindUserByEmail(email).FirstOrDefault().UserID;

            }

            return userID;

        }

        public int FindUserByFacebookID(long facebookID)
        {
            int userID = 0;

            using (var context = new RegistrationEntities())
            {

                userID = context.spFindUserByFacebookID(facebookID).FirstOrDefault().UserID;

            }

            return userID;
        }

        public User SelectUserByEmail(string email)
        {
            User user = null;

            using (var context = new RegistrationEntities())
            {
                spSelectUserByEmail_Result userEF = context.spSelectUserByEmail(email).FirstOrDefault();

                if (userEF!=null)
                {
                    user = new User();
                    user.ActivationDate = userEF.ActivationDate.HasValue ? userEF.ActivationDate.Value : DateTime.MinValue;
                    user.ActivityID = userEF.ActivityID.HasValue ? userEF.ActivityID.Value : 0;
                    user.BirthDate = userEF.BirthDate.HasValue ? userEF.BirthDate.Value : DateTime.MinValue;
                    user.CreatedDate = userEF.CreatedDate;
                    user.CreatedBy = userEF.CreatedBy.HasValue ? userEF.CreatedBy.Value : 0;
                    user.Description = userEF.Description;
                    user.Email = userEF.Email;
                    user.FacebookID = userEF.FacebookID.HasValue ? userEF.FacebookID.Value : 0;
                    user.FirstName = userEF.FirstName;
                    user.Gender = userEF.Gender.HasValue ? userEF.Gender.Value : 0;
                    user.Heigh = userEF.Heigh.HasValue ? userEF.Heigh.Value : 0;
                    user.HeighDec = userEF.HeighDec.HasValue ? userEF.HeighDec.Value : 0;
                    user.HeighInt = userEF.HeighInt.HasValue ? userEF.HeighInt.Value : 0;
                    user.IsApproved = userEF.IsApproved.HasValue ? userEF.IsApproved.Value : false;
                    user.IsLockedOut = userEF.IsLockedOut.HasValue ? userEF.IsLockedOut.Value : false;
                    user.LastLoginDate = userEF.LastLoginDate.HasValue ? userEF.LastLoginDate.Value : DateTime.MinValue;
                    user.LastName = userEF.LastName;
                    user.LastUpdatedBy = userEF.LastUpdatedBy.HasValue ? userEF.LastUpdatedBy.Value : 0;
                    user.LastUpdatedDate = userEF.LastUpdatedDate.HasValue ? userEF.LastUpdatedDate.Value : DateTime.MinValue;
                    user.Password = userEF.Password;
                    user.TerminationDate = userEF.TerminationDate.HasValue ? userEF.TerminationDate.Value : DateTime.MinValue;
                    user.UserID = userEF.UserID;
                    user.CurrentProgram = _workoutRepository.SelectCurrentUserProgram(user.UserID);
                    user.IsProfileComplete = this.IsProfileComplete(user.UserID);
                    user.Weight = userEF.Weight.HasValue ? userEF.Weight.Value : 0;
                    user.BMI = userEF.BMI.HasValue ? userEF.BMI.Value : 0;
                    user.Calories = userEF.Calories.HasValue ? userEF.Calories.Value : 0;
                    if (userEF.GoalID.HasValue)
                    {
                        spSelectGoalByID_Result goalEF = context.spSelectGoalByID(userEF.GoalID.Value).FirstOrDefault();
                        Goal goal = new Goal();
                        goal.GoalID = goalEF.GoalID;
                        goal.GoalName = goalEF.GoalName;
                        goal.IsEnabled = goalEF.IsEnabled;
                        goal.CreatedDate = goalEF.CreatedDate;
                        user.Goal = goal;
                    }  
                }
            }

            return user;
        }

        public User SelectUserByID(int userID)
        {
            User user = null;
            
            using (var context = new RegistrationEntities())
            {
                spSelectUserByID_Result userEF = context.spSelectUserByID(userID).FirstOrDefault();
                if (userEF != null)
                {
                    user = new User();
                    user.ActivationDate = userEF.ActivationDate.HasValue ? userEF.ActivationDate.Value : DateTime.MinValue;
                    user.ActivityID = userEF.ActivityID.HasValue ? userEF.ActivityID.Value : 0;
                    user.BirthDate = userEF.BirthDate.HasValue ? userEF.BirthDate.Value : DateTime.MinValue;
                    user.CreatedDate = userEF.CreatedDate;
                    user.CreatedBy = userEF.CreatedBy.HasValue ? userEF.CreatedBy.Value : 0;
                    user.Description = userEF.Description;
                    user.Email = userEF.Email;
                    user.FacebookID = userEF.FacebookID.HasValue ? userEF.FacebookID.Value : 0;
                    user.FirstName = userEF.FirstName;
                    user.Gender = userEF.Gender.HasValue ? userEF.Gender.Value : 0;
                    user.Heigh = userEF.Heigh.HasValue ? userEF.Heigh.Value : 0;
                    user.HeighDec = userEF.HeighDec.HasValue ? userEF.HeighDec.Value : 0;
                    user.HeighInt = userEF.HeighInt.HasValue ? userEF.HeighInt.Value : 0;
                    user.IsApproved = userEF.IsApproved.HasValue ? userEF.IsApproved.Value : false;
                    user.IsLockedOut = userEF.IsLockedOut.HasValue ? userEF.IsLockedOut.Value : false;
                    user.LastLoginDate = userEF.LastLoginDate.HasValue ? userEF.LastLoginDate.Value : DateTime.MinValue;
                    user.LastName = userEF.LastName;
                    user.LastUpdatedBy = userEF.LastUpdatedBy.HasValue ? userEF.LastUpdatedBy.Value : 0;
                    user.LastUpdatedDate = userEF.LastUpdatedDate.HasValue ? userEF.LastUpdatedDate.Value : DateTime.MinValue;
                    user.Password = userEF.Password;
                    user.TerminationDate = userEF.TerminationDate.HasValue ? userEF.TerminationDate.Value : DateTime.MinValue;
                    user.UserID = userEF.UserID;
                    user.CurrentProgram = _workoutRepository.SelectCurrentUserProgram(user.UserID);
                    user.IsProfileComplete = this.IsProfileComplete(user.UserID);
                    user.Weight = userEF.Weight.HasValue ? userEF.Weight.Value : 0;
                    user.BMI = userEF.BMI.HasValue ? userEF.BMI.Value : 0;
                    user.Calories = userEF.Calories.HasValue ? userEF.Calories.Value : 0;
                    if (userEF.GoalID.HasValue)
                    {
                        spSelectGoalByID_Result goalEF = context.spSelectGoalByID(userEF.GoalID.Value).FirstOrDefault();
                        Goal goal = new Goal();
                        goal.GoalID = goalEF.GoalID;
                        goal.GoalName = goalEF.GoalName;
                        goal.IsEnabled = goalEF.IsEnabled;
                        goal.CreatedDate = goalEF.CreatedDate;
                        user.Goal = goal;
                    }  

                }
            }

            return user;

        }

        public User SelectUserByFacebookID(long facebookID)
        {
            User user = null;

            using (var context = new RegistrationEntities())
            {
                spSelectUserByFacebookID_Result userEF = context.spSelectUserByFacebookID(facebookID).FirstOrDefault();

                if (userEF!=null)
                {
                    user = new User();
                    user.ActivationDate = userEF.ActivationDate.HasValue ? userEF.ActivationDate.Value : DateTime.MinValue;
                    user.ActivityID = userEF.ActivityID.HasValue ? userEF.ActivityID.Value : 0;
                    user.BirthDate = userEF.BirthDate.HasValue ? userEF.BirthDate.Value : DateTime.MinValue;
                    user.CreatedDate = userEF.CreatedDate;
                    user.CreatedBy = userEF.CreatedBy.HasValue ? userEF.CreatedBy.Value : 0;
                    user.Description = userEF.Description;
                    user.Email = userEF.Email;
                    user.FacebookID = userEF.FacebookID.HasValue ? userEF.FacebookID.Value : 0;
                    user.FirstName = userEF.FirstName;
                    user.Gender = userEF.Gender.HasValue ? userEF.Gender.Value : 0;
                    user.Heigh = userEF.Heigh.HasValue ? userEF.Heigh.Value : 0;
                    user.HeighDec = userEF.HeighDec.HasValue ? userEF.HeighDec.Value : 0;
                    user.HeighInt = userEF.HeighInt.HasValue ? userEF.HeighInt.Value : 0;
                    user.IsApproved = userEF.IsApproved.HasValue ? userEF.IsApproved.Value : false;
                    user.IsLockedOut = userEF.IsLockedOut.HasValue ? userEF.IsLockedOut.Value : false;
                    user.LastLoginDate = userEF.LastLoginDate.HasValue ? userEF.LastLoginDate.Value : DateTime.MinValue;
                    user.LastName = userEF.LastName;
                    user.LastUpdatedBy = userEF.LastUpdatedBy.HasValue ? userEF.LastUpdatedBy.Value : 0;
                    user.LastUpdatedDate = userEF.LastUpdatedDate.HasValue ? userEF.LastUpdatedDate.Value : DateTime.MinValue;
                    user.Password = userEF.Password;
                    user.TerminationDate = userEF.TerminationDate.HasValue ? userEF.TerminationDate.Value : DateTime.MinValue;
                    user.UserID = userEF.UserID;
                    user.CurrentProgram = _workoutRepository.SelectCurrentUserProgram(user.UserID);
                    user.IsProfileComplete = this.IsProfileComplete(user.UserID);
                    user.Weight = userEF.Weight.HasValue ? userEF.Weight.Value : 0;
                    user.BMI = userEF.BMI.HasValue ? userEF.BMI.Value : 0;
                    user.Calories = userEF.Calories.HasValue ? userEF.Calories.Value : 0;
                    if (userEF.GoalID.HasValue)
                    {
                        spSelectGoalByID_Result goalEF = context.spSelectGoalByID(userEF.GoalID.Value).FirstOrDefault();
                        Goal goal = new Goal();
                        goal.GoalID = goalEF.GoalID;
                        goal.GoalName = goalEF.GoalName;
                        goal.IsEnabled = goalEF.IsEnabled;
                        goal.CreatedDate = goalEF.CreatedDate;
                        user.Goal = goal;                     
                    }                    
                }
            }

            return user;
        }

        

        /// <summary>
        /// 
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        /// <remarks>
        /// Se llama cuando el usuario inicia su programa.   
        /// Si ya inicio almenos un programa la siguiente vez, el birthdate y sexo no deben cambiar
        /// </remarks>
        public User UpdateUserRegistration(User user)
        {            

            using (var context = new RegistrationEntities())
            {
                decimal heigh = user.HeighInt + UnitConverter.CentimetersToMeters(user.HeighDec); //estatura en metros
                                
                user.BMI = Selery.BO.Nutrition.Profile.GetBMI(heigh, user.Weight);
                
                int age = Selery.Library.Common.Helper.GetAge(user.BirthDate);
                              

                //selecctionar el goaltype en base al bmi
                Selery.BO.Core.Enum.GoalType goalTypeID = Selery.BO.Nutrition.Profile.GetGoalType(user.BMI);
                                
                                
                //TODO: por ahora solo tenemos 2 goals, el 1 es de LoseWeight y el 2 es de Maintain
                //cuando haya mas Goals vamos a tener que hacer refactor a este metodo.

                int goalID = (goalTypeID == Selery.BO.Core.Enum.GoalType.LoseWeight ? (int)Selery.BO.Core.Enum.GoalType.LoseWeight : (int)Selery.BO.Core.Enum.GoalType.Maintain);

                
                //Las calorias ya vienen en el usuario
                int? rowcount = context.spUserRegistrationUpdate(user.UserID,
                     user.Gender,
                     user.HeighInt,
                     user.HeighDec,
                     user.BirthDate,
                     goalID,
                     user.BMI,
                     user.Calories).SingleOrDefault();
                

                decimal? id = context.spUserActivityInsert(user.UserID, user.ActivityID).SingleOrDefault();

            }

            using (var context = new WorkoutEntities())
            {
                //iniciar el programa
                //guardar cual es el BMI del usuario al inicio del programa
                int? rowcount = context.spUserProgramUpdate(user.UserID, user.CurrentProgram.ProgramID, user.BMI).SingleOrDefault();
            }

            //insertar el peso
            this.UserWeightInsert(user.UserID, user.Weight);
            
            //inicializar menu           
            using (var context = new  NutritionEntities())
            {  
                
                int? rowcount = context.spUserDailyMenuInitialize(user.UserID, user.CurrentProgram.ProgramID).SingleOrDefault();
            }

            return this.SelectUserByID(user.UserID);
        }

        public User UpdateUserProfile(User user)
        {
            using (var context = new RegistrationEntities())
            {
                decimal? rowcount=context.spUserProfileUpdate(user.UserID, user.Weight, user.ActivityID).SingleOrDefault();
                return this.SelectUserByID(user.UserID);//refrescar el usuario y regresarlo
            }
        }

        public User LoginByEmail(string email,byte[] password)
        {
            int? userID=0;
            User retUser=null;

            using (var context = new RegistrationEntities())
            {   
                userID = context.spLoginByEmail(email, password).SingleOrDefault();
            }

            if (userID.HasValue && userID.Value > 0)
            {
                retUser = this.SelectUserByID(userID.Value);
            }

            return retUser;
        }

        public IEnumerable<Activity> SelectActivity()
        {
            List<Activity> activityList = new List<Activity>();
            IEnumerable<spSelectActivity_Result> activityEFList;
            using (var context = new RegistrationEntities())
            {
                activityEFList = context.spSelectActivity().ToList();
            }

            foreach (spSelectActivity_Result item in activityEFList)
            {
                Activity activity = new Activity();
                activity.ActivityID = item.ActivityID;
                activity.ActivityName = item.ActivityName;
                activity.Factor = item.Factor;
                activityList.Add(activity);
            }

            return activityList;
        }

        public IEnumerable<Goal> SelectGoal()
        {
            List<Goal> goalList = new List<Goal>();
            IEnumerable<spSelectGoal_Result> goalEFList;
            using (var context = new RegistrationEntities())
            {
                goalEFList = context.spSelectGoal().ToList();
            }

            foreach (spSelectGoal_Result item in goalEFList)
            {
                Goal goal = new Goal();
                goal.GoalID = item.GoalID;
                goal.GoalName = item.GoalName;
                goal.IsEnabled = item.IsEnabled;
                goal.CreatedDate = item.CreatedDate;
                goalList.Add(goal);
            }

            return goalList;
        }

        public int UserWeightInsert(int userID, decimal weight)
        {
            decimal? userWeightID = 0;

            using (var context = new RegistrationEntities())
            {
                userWeightID = context.spUserWeightInsert(userID,weight).FirstOrDefault().UserWeightID;
            }

            return Convert.ToInt32(userWeightID.Value);

        }

        public Boolean IsProfileComplete(int userID)
        {
            spIsProfileComplete_Result retVal;

            using (var context = new RegistrationEntities())
            {
              retVal = context.spIsProfileComplete(userID).FirstOrDefault();
            }

            return retVal.IsProfileComplete.HasValue ?  retVal.IsProfileComplete.Value : false;
        }

    }

}
