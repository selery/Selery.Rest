using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Selery.BO.Entity.Registration;
using Selery.Library.Common;

namespace Selery.UnitTest
{
    [TestClass]
    public class UnitTest1
    {

        [TestMethod]
        public void UserUpdateFoodMenu()
        {
            Selery.BO.Entity.Nutrition.Food food = new Selery.BO.Entity.Nutrition.Food();
            food.FoodID = 1;
            food.Calories = 1.1m;
            food.Carbohydrate = 2.1m;
            food.Fat = 3.1m;
            food.Protein = 4.1m;
            food.Qty = 1;
            

        }
    }
}
