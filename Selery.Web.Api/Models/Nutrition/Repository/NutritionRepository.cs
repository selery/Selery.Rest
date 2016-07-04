using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Selery.Web.Api.Models.Registration.Interface;
using Selery.Model;
using Selery.Model.Entity.Registration;
using Selery.Model.Entity.Nutrition;
using Selery.BO.Entity.Registration;
using Selery.BO.Entity.Nutrition;
using Selery.Library.Common;
using Selery.Web.Api.Models.Nutrition.Repository;
using Selery.Web.Api.Models.Workout.Repository;
using Selery.Web.Api.Models.Nutrition.Interface;
using Selery.Web.Api.Models.Workout.Interface;


namespace Selery.Web.Api.Models.Nutrition.Repository
{
    public class NutritionRepository : INutrition
    {
        private IWorkout _workoutRepository;

        public NutritionRepository()
        {
            _workoutRepository = new WorkoutRepository();
        }

        public decimal GetUserCalories(User user)
        {

            decimal calories = 0;
            decimal heightCentimeters = UnitConverter.MetersToCentimeters(user.HeighInt) + user.HeighDec;//estatura en centimetros
            int age = Selery.Library.Common.Helper.GetAge(user.BirthDate.Value);
            spSelectActivityByID_Result activity = null;
            using (var context = new RegistrationEntities())
            {
                activity = context.spSelectActivityByID(user.ActivityID).FirstOrDefault();
            }

            //calcular el gasto de calorias.
            if (user.Gender == (int)Selery.BO.Core.Enum.Gender.Male)
            {
                //( (10*peso)+(6.25*estatura)-(5*edad)+5 )*factor
                calories = ((10 * user.Weight) + ((decimal)6.25 * heightCentimeters) - (5 * age) + 5) * activity.Factor;

            }
            else
            {
                //( ( 10*peso)+(6.25*estatura)-(5*edad)-161 )*factor
                calories = ((10 * user.Weight) + ((decimal)6.25 * heightCentimeters) - (5 * age) + 161) * activity.Factor;
            }

            return calories;

        }

        public IEnumerable<UserDailyMenu> GetUserDailyMenu(int userID, int day)
        {
            List<UserDailyMenu> userDailyMenuList = new List<UserDailyMenu>();
            IEnumerable<spUserDailyMenuSelectByDay_Result> userDailyMenuEFList;
            using (var context = new NutritionEntities())
            {
                userDailyMenuEFList = context.spUserDailyMenuSelectByDay(userID, day).ToList();
                foreach (spUserDailyMenuSelectByDay_Result item in userDailyMenuEFList)
                {
                    UserDailyMenu userDailyMenu = new UserDailyMenu();
                    userDailyMenu.MenuMealTimeFoodXRefID = item.MenuMealTimeFoodXRefID;
                    userDailyMenu.UserProgramXRefID = item.UserProgramXRefID;
                    userDailyMenu.MenuMealTimeOrderID = item.MenuMealTimeOrderID;
                    userDailyMenu.MealTimeTypeID = item.MealTimeTypeID;
                    userDailyMenu.MealTimeName = item.MealTimeName;
                    userDailyMenu.FoodName = item.FoodName;
                    userDailyMenu.Qty = item.Qty;
                    userDailyMenu.Calories = item.Calories;
                    userDailyMenuList.Add(userDailyMenu);

                }
            }

            return userDailyMenuList;
        }

        public decimal GetUserMenuCalories(int userID, int programID)
        {
            decimal? calories;
            using (var context = new NutritionEntities())
            {
                calories = context.spUserMenuCalories(userID, programID).FirstOrDefault().Calories;                
            }
            return calories.HasValue ? calories.Value : 0;

        }
                
        public IEnumerable<spSelectFoodBySponsorAndMealTimeType_Result> GetFoodBySponsorAndMealTimeType(int sponsorID, int mealTimeTypeID)
        {
            List<spSelectFoodBySponsorAndMealTimeType_Result> foodList=null;

            using (var context = new NutritionEntities())
            {
                foodList = context.spSelectFoodBySponsorAndMealTimeType(sponsorID, mealTimeTypeID).ToList();
            }

            return foodList;
        }

        public int UserUpdateFoodMenu(int menuMealTimeFoodXRefID, Food food)
        {
            spUserProgramDayMealTimeFoodXRefUpdate_Result result=null;

            using (var context = new NutritionEntities())
            {               
                result = context.spUserProgramDayMealTimeFoodXRefUpdate(menuMealTimeFoodXRefID, food.FoodID, food.Carbohydrate, food.Protein, food.Fat, food.Calories, food.Qty).FirstOrDefault();                                
            }

            return result!=null ?result.RowCount:0;
        }

     }

}
