using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Selery.BO.Entity.Nutrition
{
    public class UserDailyMenu
    {
        public int MenuMealTimeFoodXRefID { get; set; }
        public int UserProgramXRefID { get; set; }
        public int MenuMealTimeOrderID { get; set; }
        public int MealTimeTypeID { get; set; }
        public string MealTimeName { get; set; }
        public string FoodName { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<decimal> Calories { get; set; }

    }
}
