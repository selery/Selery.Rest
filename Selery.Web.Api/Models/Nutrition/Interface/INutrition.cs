using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Selery.BO.Entity.Registration;
using Selery.BO.Entity.Nutrition;
using Selery.Model.Entity.Nutrition;

namespace Selery.Web.Api.Models.Nutrition.Interface
{
    public interface INutrition
    {
        decimal GetUserCalories(User user);
        IEnumerable<UserDailyMenu> GetUserDailyMenu(int userID, int day);
        decimal GetUserMenuCalories(int userID, int programID);
        IEnumerable<spSelectFoodBySponsorAndMealTimeType_Result> GetFoodBySponsorAndMealTimeType(int sponsorID, int mealTimeTypeID);
        int UserUpdateFoodMenu(int menuMealTimeFoodXRefID, Food food);
    }
}
