using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Net;
using System.Net.Http;

using Selery.Web.Api.Models.Nutrition.Interface;
using Selery.BO.Entity.Registration;
using Selery.Model.Entity.Registration;
using Selery.Model.Entity.Nutrition;
using Selery.BO.Entity.Nutrition;


namespace Selery.Web.Api.Controllers.Nutrition
{
    public class NutritionController : ApiController
    {
        private readonly INutrition repository;

        public NutritionController(INutrition repository)
        {
            this.repository = repository;
        }

        [HttpPost, ActionName("usercalories")]
        public decimal GetUserCalories([FromBody] User user)
        {

            return repository.GetUserCalories(user);
        }

        [HttpGet, ActionName("userdailymenu")]
        public IEnumerable<UserDailyMenu> GetUserDailyMenu(int userID,  int day)
        {
            return repository.GetUserDailyMenu(userID, day);
        }

        [HttpGet, ActionName("usermenucalories")]
        public decimal GetUserMenuCalories(int userID, int programID)
        {
            return repository.GetUserMenuCalories(userID, programID);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sponsorID"></param>
        /// <param name="mealTimeTypeID"></param>
        /// <returns></returns>
        /// <remarks>
        /// El objeto spSelectFoodBySponsorAndMealTimeType_Result es igual al objeto Food
        /// </remarks>
        [HttpGet, ActionName("foodbysponsor")]        
        public IEnumerable<spSelectFoodBySponsorAndMealTimeType_Result> GetFoodBySponsorAndMealTimeType(int sponsorID, int mealTimeTypeID)
        {
            return repository.GetFoodBySponsorAndMealTimeType(sponsorID, mealTimeTypeID);
        }

        [HttpPost, ActionName("userupdatefoodmenu")]
        public int UserUpdateFoodMenu(int menuMealTimeFoodXRefID, [FromBody] Food food)
        {
            return repository.UserUpdateFoodMenu(menuMealTimeFoodXRefID, food);
        }
    }
}
