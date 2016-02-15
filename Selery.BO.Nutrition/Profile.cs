using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

using Selery.BO.Core;
using Selery.BO.Entity.Registration;
using Selery.BO.Entity.Nutrition;

namespace Selery.BO.Nutrition
{
    public class Profile : BizObject
    {
        /// <summary>
        /// Calcula el BMI
        /// </summary>
        /// <param name="height">Estatura en metros</param>
        /// <param name="weight">Peso en Kg</param>
        /// <returns>Peso entre estatura al cuadrado</returns>
        public static decimal GetBMI(decimal height, decimal weight)
        {
            return weight / Convert.ToDecimal(Math.Pow((double)height,2));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="gender"></param>
        /// <param name="height">Estatura en centimetros</param>
        /// <param name="weithg">Peso en Kg</param>
        /// <param name="age"></param>
        /// <param name="activity"></param>
        /// <returns></returns>
        public static Selery.BO.Core.Enum.GoalType GetGoalType(decimal bmi)
        {           
            Selery.BO.Core.Enum.GoalType goalType = Selery.BO.Core.Enum.GoalType.LoseWeight;

            if (bmi >= 25) goalType = Selery.BO.Core.Enum.GoalType.LoseWeight;
            if (bmi < 25) goalType = Selery.BO.Core.Enum.GoalType.Maintain;
           
            return goalType;
        }

        public decimal GetUserCalories(User user)
        {
            return 0;
        }

        public IEnumerable<UserDailyMenu> GetUserDailyMenu(int userID, int day)
        {
            return null;
        }

        public decimal GetUserMenuCalories(int userID, int programID)
        {
            return 0;

        }

        public IEnumerable<Food> GetFoodBySponsorAndMealTimeType(int sponsorID, int mealTimeTypeID)
        {
            return null;
        }

        public int UserUpdateFoodMenu(int menuMealTimeFoodXRefID, Food food)
        {
            return 0;
        }

    }
}
