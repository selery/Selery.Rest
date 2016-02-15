using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Selery.BO.Entity.Nutrition
{
    public class Food
    {
        public int FoodID { get; set; }
        public int MealTimeTypeID { get; set; }
        public string MealTimeName { get; set; }
        public Nullable<int> UserID { get; set; }
        public string Name { get; set; }
        public string ShortName { get; set; }
        public string SearchableName { get; set; }
        public Nullable<int> SearchableNameLength { get; set; }
        public Nullable<decimal> Carbohydrate { get; set; }
        public Nullable<decimal> Protein { get; set; }
        public Nullable<decimal> Fat { get; set; }
        public Nullable<decimal> Calories { get; set; }
        public Nullable<decimal> Qty { get; set; }
        public Nullable<int> UnitID { get; set; }
        public string UnitName { get; set; }
        public Nullable<int> SponsorID { get; set; }
        public string SponsorName { get; set; }
        public string SponsorDescription { get; set; }
        public string TAG { get; set; }
        public Nullable<int> SourceID { get; set; }
        public string SourceName { get; set; }
        public System.DateTime CreatedDate { get; set; }

    }
}
